using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FlipTimer.Services
{
    internal class TimerService
    {
        private DispatcherTimer? _dispatcherTimer;
        public void Start(TimeSpan timeSpan)
        {
            Stop();

            _dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 1, 0), DispatcherPriority.Normal, delegate
            {
                timeSpan = timeSpan.Add(TimeSpan.FromMinutes(-1));
                if (timeSpan == TimeSpan.Zero) _dispatcherTimer.Stop();

            }, Application.Current.Dispatcher);

            _dispatcherTimer.Start();
        }

        public void Stop()
        {
            if (_dispatcherTimer != null)
            {
                _dispatcherTimer.Stop();
                _dispatcherTimer = null;
            }
        }
    }
}
