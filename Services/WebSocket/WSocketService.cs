using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AxiaFutures.Services.WebSocket
{
    internal class WSocketService : IWSocketService, IDisposable
    {
        private ClientWebSocket _webSocket;
        private CancellationTokenSource _cts;

        public event EventHandler<string> MessageReceived;
        public event EventHandler<string> ConnectionStatusChanged;

        public bool IsConnected => _webSocket?.State == WebSocketState.Open;

        public async Task ConnectAsync(string uri)
        {
            try
            {
                _cts = new CancellationTokenSource();
                _webSocket = new ClientWebSocket();

                await _webSocket.ConnectAsync(new Uri(uri), _cts.Token);
                OnConnectionStatusChanged("Conectado");

                _ = Task.Run(() => ReceiveMessages(_cts.Token), _cts.Token);
            }
            catch (Exception ex)
            {
                OnConnectionStatusChanged($"Erro: {ex.Message}");
                throw;
            }
        }

        public async Task DisconnectAsync()
        {
            if (_webSocket == null) return;

            try
            {
                _cts?.Cancel();

                if (IsConnected)
                {
                    await _webSocket.CloseAsync(
                        WebSocketCloseStatus.NormalClosure,
                        "Fechado pelo usuário",
                        CancellationToken.None);
                }

                OnConnectionStatusChanged("Desconectado");
            }
            catch (Exception ex)
            {
                OnConnectionStatusChanged($"Erro ao desconectar: {ex.Message}");
                throw;
            }
            finally
            {
                _webSocket?.Dispose();
                _webSocket = null;
            }
        }

        private async Task ReceiveMessages(CancellationToken cancellationToken)
        {
            var buffer = new byte[1024 * 32];

            while (!cancellationToken.IsCancellationRequested && IsConnected)
            {
                try
                {

                    var result = await _webSocket.ReceiveAsync(
                        buffer, cancellationToken);

                    var t = Encoding.UTF8.GetString(buffer, 0, result.Count);

                    if (result.MessageType != WebSocketMessageType.Text)
                    {
                        break;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    OnMessageReceived(message);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    OnConnectionStatusChanged($"Erro: {ex.Message}");
                    break;
                }
            }
        }

        protected virtual void OnMessageReceived(string message)
        {
            var resultFilterMessage = filterMessage(message);
            if (resultFilterMessage == null)
            {
                return;
            }
            
            MessageReceived?.Invoke(this, resultFilterMessage);
        }

        private string? filterMessage(string message)
        {
            try
            {
                var json = JObject.Parse(message);
                var comp = json["type"].ToString();
                if (comp == "message")
                {
                    return json["content"][0]["headline"].ToString();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected virtual void OnConnectionStatusChanged(string status)
        {
            ConnectionStatusChanged?.Invoke(this, status);
        }

        public void Dispose()
        {
            _cts?.Cancel();
            _webSocket?.Dispose();
        }
    }

}
