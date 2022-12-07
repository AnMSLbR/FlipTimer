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
        public event EventHandler<TimerEventArgs> TimeSpanChanged;
        private DispatcherTimer? _dispatcherTimer;
        private DateTime? _startDate;

        public DateTime? StartDate { get => _startDate; set => _startDate = value; }

        public bool IsRunning 
        {
            get
            {
                return _dispatcherTimer == null ? false : _dispatcherTimer.IsEnabled;
            }
        }

        public void Start(TimeSpan timeSpan)
        {
            Stop();

            _dispatcherTimer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1));
                if (timeSpan == TimeSpan.Zero) _dispatcherTimer.Stop();
                if (timeSpan.Seconds == 0)
                    TimeSpanChanged?.Invoke(this, new TimerEventArgs(timeSpan));
            
            }, Application.Current.Dispatcher);
            
            _dispatcherTimer.Start();
            StartDate = DateTime.Now;
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
