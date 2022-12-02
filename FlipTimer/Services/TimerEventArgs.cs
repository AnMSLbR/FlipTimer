using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipTimer.Services
{
    internal class TimerEventArgs : EventArgs
    {
        public TimeSpan RemainingTimeSpan { get; }

        public TimerEventArgs(TimeSpan timeSpan)
        {
            RemainingTimeSpan = timeSpan;
        }
    }
}
