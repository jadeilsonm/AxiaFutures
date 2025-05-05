using AxiaFutures.Services.MessageProcessor;
using AxiaFutures.Services.Speech;
using AxiaFutures.Services.WebSocket;

namespace AxiaFutures.Forms
{
    public partial class Feed : Form
    {
        private readonly IWSocketService _webSocketService;
        private readonly IMessageProcessorService _messageProcessor;
        private readonly ITextToSpeechService _textToSpeechService;

        public Feed(IWSocketService webSocketService, IMessageProcessorService messageProcessor, ITextToSpeechService textToSpeechService)
        {
            InitializeComponent();

            _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));
            _messageProcessor = messageProcessor ?? throw new ArgumentNullException(nameof(messageProcessor));
            _textToSpeechService = textToSpeechService ?? throw new ArgumentNullException(nameof(textToSpeechService));

            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            _webSocketService.MessageReceived += OnWebSocketMessageReceived;
            _webSocketService.ConnectionStatusChanged += OnConnectionStatusChanged;
        }


        private void OnWebSocketMessageReceived(object sender, string message)
        {
            Invoke((MethodInvoker)delegate
            {
                if (txtMessage.Text.Contains("Aguardando envio de mensagem..."))
                {
                    txtMessage.Text = "";
                }
                if (txtMessage.Lines.Length == 5)
                {
                    txtMessage.Text = "";
                }
                txtMessage.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
                _messageProcessor.EnqueueMessage(message);
            });
        }

        private void OnConnectionStatusChanged(object sender, string status)
        {
            Invoke((MethodInvoker)delegate
            {
                lblStatus.Text = status;
                lblStatus.ForeColor = status.Contains("Erro") ? System.Drawing.Color.Red :
                    status == "Conectado" ? System.Drawing.Color.AliceBlue :
                    System.Drawing.Color.DarkGoldenrod;
            });
        }


        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await InitializeConnectionAsync();
        }

        private async Task InitializeConnectionAsync()
        {
            try
            {
                await _webSocketService.ConnectAsync("wss://edge-api.axiafutures.com/ws/?token=U2FsdGVkX1+YcfF5A506hKmuKwlK2a4WErOATfH/Ek9GtuMmtY0FbGqnH892r4B8");
                btnDisconnect.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar automaticamente: {ex.Message}");
                btnDisconnect.Enabled = false;
            }
        }

        private void Feed_Load(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Maximum;
            lblVolume.Text = $"Volume: {100}%";
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _messageProcessor.IsReadingEnabled = checkBox1.Checked;
            _messageProcessor.StartProcessing();
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _messageProcessor.SetVolume(trackBar1.Value);
            lblVolume.Text = $"Volume: {trackBar1.Value * 10}%";
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect.Enabled = false;
            this.disconect();
        }

        private void Feed_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.disconect();
            _messageProcessor.StopProcessing();
        }

        private async void disconect()
        {
            try
            {
                await _webSocketService.DisconnectAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao desconectar: {ex.Message}");
                btnDisconnect.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _textToSpeechService.SetVolume(trackBar1.Value);
            _textToSpeechService.Speak(textBox1.Text);
        }
    }
}
