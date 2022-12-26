using FlipTimer.Commands;
using FlipTimer.Models;
using FlipTimer.Stores;
using Syncfusion.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlipTimer.ViewModels
{
    internal class SettingViewModel : ViewModelBase
    {

        public ICommand StartCommand { get; }

        private TimeSpanModel _timeSpan;
        private TimeSpan? _days;
        private TimeSpan? _hours;
        private DateTime? _date;
        private DateTime? _time;
        public TimeSpan? Days
        {
            get => _days;
            set
            {
                _days = value;
                _timeSpan.Days = _days;
                OnPropertyChanged("Days");
            }
        }
        public TimeSpan? Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                _timeSpan.Hours = _hours;
                OnPropertyChanged("Hours");
            }
        }
        public DateTime? Date
        {
            get => _date;
            set
            {
                _date = value;
                SetEndDate();
                OnPropertyChanged("Date");
            }
        }

        public DateTime? Time
        {
            get => _time;
            set
            {
                _time = value;
                SetEndDate();
                OnPropertyChanged("Time");
            }
        }
        private ViewModelBase _viewModel;
        public SettingViewModel(NavigationStore navigationStore, TimeSpanModel model, ViewModelBase previousViewModel)
        {
            _timeSpan = model;
            _viewModel = previousViewModel;
            NavigateCommand = new NavigateCommand<TimerViewModel>(navigationStore, _viewModel);
            StartCommand = new StartCommand(_timeSpan);
        }

        private void SetEndDate()
        {
            if (Time != null || Date != null)
            {
                if (Time == null)
                    _time = default(DateTime);
                if (Date == null)
                    _date = DateTime.Now;
                _timeSpan.EndDate = ((DateTime)Date!).Date + new TimeSpan(((DateTime)Time!).TimeOfDay.Hours, ((DateTime)Time!).TimeOfDay.Minutes, 0);
            }
        }

    }
}
