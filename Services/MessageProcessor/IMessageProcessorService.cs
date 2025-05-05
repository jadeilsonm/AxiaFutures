using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiaFutures.Services.MessageProcessor
{
    public interface IMessageProcessorService
    {
        void EnqueueMessage(string message);
        void StartProcessing();
        void StopProcessing();
        void SetVolume(int volume);
        bool IsReadingEnabled { get; set; }
    }
}
