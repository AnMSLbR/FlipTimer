using FlipTimer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlipTimer.Models
{
    internal class TimeSpanModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private TimeSpan _days;
        private TimeSpan _hours;
        private TimeSpan _totalTimeSpan;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private TimerService timer;

        [JsonIgnore]
        public TimeSpan Days 
        { 
            get => _days; 
            set
            {
                _days = value;
                OnPropertyChanged("Days");
            }
        }

        [JsonIgnore]
        public TimeSpan Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged("Hours");
            }
        }

        [JsonPropertyName("TimeSpan")]
        public TimeSpan TotalTimeSpan
        {
            get => _totalTimeSpan;
            set
            {
                _totalTimeSpan = value;
                OnPropertyChanged("TotalTimeSpan");
            }
        }

        public DateTime? StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public DateTime? EndDate
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
            timer.TimeSpanChanged += Timer_TimeSpanChangedEventHandler;
        }

        public void StartCount()
        {
            if (EndDate == null)
            {
                TotalTimeSpan = CalculateTotalTimeSpan(Days, Hours);
                StartTimer(TotalTimeSpan);
                StartDate = timer.StartDate;
                CalculateEndDate();
            }
            else if (EndDate <= DateTime.Now)
            {
                MessageBox.Show($"Time is over at {EndDate}");
                ResetTimer();
            }
            else
            {
                TotalTimeSpan = (DateTime)EndDate! - DateTime.Now;
                StartTimer(TotalTimeSpan);
            }
            Days = default(TimeSpan);
            Hours = default(TimeSpan);
        }

        public void StartTimer(TimeSpan timeSpan)
        {
            if (timeSpan > TimeSpan.Zero)
                timer.Start(timeSpan);
        }

        public void StopTimer()
        {
            if (timer.IsRunning)
                timer.Stop();
        }

        public void ResetTimer()
        {
            StopTimer();
            StartDate = default(DateTime?);
            EndDate = default(DateTime?);
            TotalTimeSpan = TimeSpan.Zero;
        }

        private TimeSpan CalculateTotalTimeSpan(TimeSpan days, TimeSpan hours)
        {
            return days + hours;
        }

        private TimeSpan CalculateTotalTimeSpan(DateTime endDate)
        {
            return endDate - DateTime.Now;
        }

        private void Timer_TimeSpanChangedEventHandler(object? sender, TimerEventArgs eventArgs)
        {
            TotalTimeSpan = eventArgs.RemainingTimeSpan;
        }

        private void CalculateEndDate()
        {
            if(StartDate != null)
                EndDate = ((DateTime)StartDate).Add(TotalTimeSpan);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
