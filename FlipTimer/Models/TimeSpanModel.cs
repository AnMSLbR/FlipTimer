using FlipTimer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlipTimer.Models
{
    internal class TimeSpanModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private TimeSpan _days;
        private TimeSpan _hours;
        private TimeSpan _totalTimeSpan;
        private DateTime _startDate;
        private DateTime _endDate;
        private TimerService timer;

        public TimeSpan Days 
        { 
            get => _days; 
            set
            {
                _days = value;
                OnPropertyChanged("Days");
            }
        }

        public TimeSpan Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged("Hours");
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public TimeSpanModel()
        {
            timer = new TimerService();
        }

        public void StartTimer()
        {
            _totalTimeSpan = CalculateTotalTimeSpan(Days, Hours);
            if (_totalTimeSpan != TimeSpan.Zero)
                timer.Start(_totalTimeSpan);
        }

        private TimeSpan CalculateTotalTimeSpan(TimeSpan days, TimeSpan hours)
        {
            return days + hours;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
