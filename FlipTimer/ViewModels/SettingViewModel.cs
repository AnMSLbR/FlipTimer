using FlipTimer.Commands;
using FlipTimer.Models;
using FlipTimer.Stores;
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
        private ViewModelBase _viewModel;
        public SettingViewModel(NavigationStore navigationStore, TimeSpanModel model, ViewModelBase previousViewModel)
        {
            _timeSpan = model;
            _viewModel = previousViewModel;
            NavigateCommand = new NavigateCommand<TimerViewModel>(navigationStore, _viewModel);
            StartCommand = new StartCommand(_timeSpan);
        }
    }
}
