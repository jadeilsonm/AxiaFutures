using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxiaFutures.Model
{
    internal class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; }
        public DateTime ReceivedTime { get; }

        public MessageReceivedEventArgs(string message)
        {
            Message = message;
            ReceivedTime = DateTime.Now;
        }
    }
}
