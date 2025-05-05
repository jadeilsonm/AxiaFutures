using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiaFutures.Services.WebSocket
{
    public interface IWSocketService
    {
        event EventHandler<string> MessageReceived;
        event EventHandler<string> ConnectionStatusChanged;
        Task ConnectAsync(string uri);
        Task DisconnectAsync();
        bool IsConnected { get; }
    }
}
