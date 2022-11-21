using FlipTimer.Commands;
using FlipTimer.Models;
using FlipTimer.Resources;
using FlipTimer.Stores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlipTimer.ViewModels
{
    internal class TimerViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }

        private Image _frontImage;
        private Image _backImage;
        private Images _images;
        private TimeSpanModel _timeSpan;
        public Image FrontImage
        {
            get { return _frontImage; }
            set
            {
                _frontImage = value;
                OnPropertyChanged("FrontImage");
            }
        }
        public Image BackImage
        {
            get { return _backImage; }
            set
            {
                _backImage = value;
                OnPropertyChanged("BackImage");
            }
        }

        public TimerViewModel(NavigationStore navigationStore, TimeSpanModel model)
        {
            _timeSpan = model;
            _timeSpan.PropertyChanged += TimeSpan_TotalTimeSpanPropertyChanged;
            _images = new Images();
            NavigateCommand = new NavigateCommand<SettingViewModel>(navigationStore, () => new SettingViewModel(navigationStore, _timeSpan));
        }

        private void TimeSpan_TotalTimeSpanPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_timeSpan.TotalTimeSpan))
            {

            }
        }
    }
}
