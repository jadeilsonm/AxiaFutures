using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiaFutures.Services.Speech
{
    public interface ITextToSpeechService
    {
        void Speak(string text);
        void SetVolume(int volume);
        void Stop();
        int CurrentVolume { get; }
    }
}
