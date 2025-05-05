using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxiaFutures.Services.Speech;

namespace AxiaFutures.Services.MessageProcessor
{
    internal class MessageProcessorService : IMessageProcessorService, IDisposable
    {
        private readonly ITextToSpeechService _ttsService;
        private readonly ConcurrentQueue<string> _messageQueue = new();
        private CancellationTokenSource _cts;
        private Task _processingTask;

        public bool IsReadingEnabled { get; set; } = true;

        public MessageProcessorService(ITextToSpeechService ttsService)
        {
            _ttsService = ttsService ?? throw new ArgumentNullException(nameof(ttsService));
        }

        public void EnqueueMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                _messageQueue.Enqueue(message);
            }
        }

        public void SetVolume(int volume)
        {
            this._ttsService.SetVolume(volume);
        }

        public void StartProcessing()
        {
            _cts = new CancellationTokenSource();
            _processingTask = Task.Run(() => ProcessMessages(_cts.Token), _cts.Token);
        }

        public void StopProcessing()
        {
            _cts?.Cancel();
            _ttsService.Stop();
        }

        private async Task ProcessMessages(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_messageQueue.TryDequeue(out var message))
                {
                    if (IsReadingEnabled.Equals(true))
                    {
                        _ttsService.Speak(message);
                    }
                    else
                    {
                        this.StartProcessing();
                    }
                }
                await Task.Delay(1000, cancellationToken);
            }
        }

        public void Dispose()
        {
            StopProcessing();
            _cts?.Dispose();
        }
    }
}
