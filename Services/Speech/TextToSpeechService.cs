using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace AxiaFutures.Services.Speech
{
    internal class TextToSpeechService : ITextToSpeechService, IDisposable
    {
        private readonly SpeechSynthesizer _synthesizer;

        public int CurrentVolume => _synthesizer.Volume;

        public TextToSpeechService()
        {
            _synthesizer = new SpeechSynthesizer();
            _synthesizer.SetOutputToDefaultAudioDevice();
        }

        public void Speak(string text)
        { 
            if (string.IsNullOrWhiteSpace(text)) return;
            _synthesizer.SpeakAsync(text);
        }

        public void SetVolume(int volume)
        {
            _synthesizer.Volume = Math.Max(0, Math.Min(100, (volume * 10)));
        }

        public void Stop()
        {
            _synthesizer.SpeakAsyncCancelAll();
        }

        public void Dispose()
        {
            _synthesizer?.Dispose();
        }
    }
}
