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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FlipTimer.ViewModels
{
    internal class TimerViewModel : ViewModelBase
    {
        private ImageSources _imageSources;
        private TimeSpanModel _timeSpan;

        private ImageSource _thousandsDaysFrontImageSource;
        private ImageSource _thousandsDaysBackImageSource;
        private ImageSource _hundredsDaysFrontImageSource;
        private ImageSource _hundredsDaysBackImageSource;
        private ImageSource _tensDaysFrontImageSource;
        private ImageSource _tensDaysBackImageSource;
        private ImageSource _onesDaysFrontImageSource;
        private ImageSource _onesDaysBackImageSource;

        private ImageSource _tensHoursFrontImageSource;
        private ImageSource _tensHoursBackImageSource;
        private ImageSource _onesHoursFrontImageSource;
        private ImageSource _onesHoursBackImageSource;
        private ImageSource _tensMinutesFrontImageSource;
        private ImageSource _tensMinutesBackImageSource;
        private ImageSource _onesMinutesFrontImageSource;
        private ImageSource _onesMinutesBackImageSource;

        #region Properties
        public ImageSource ThousandsDaysFrontImageSource
        {
            get { return _thousandsDaysFrontImageSource; }
            set
            {
                _thousandsDaysFrontImageSource = value;
                OnPropertyChanged("ThousandsDaysFrontImageSource");
            }
        }
        public ImageSource ThousandsDaysBackImageSource
        {
            get { return _thousandsDaysBackImageSource; }
            set
            {
                _thousandsDaysBackImageSource = value;
                OnPropertyChanged("ThousandsDaysBackImageSource");
            }
        }

        public ImageSource HundredsDaysFrontImageSource
        {
            get { return _hundredsDaysFrontImageSource; }
            set
            {
                _hundredsDaysFrontImageSource = value;
                OnPropertyChanged("HundredsDaysFrontImageSource");
            }
        }
        public ImageSource HundredsDaysBackImageSource
        {
            get { return _hundredsDaysBackImageSource; }
            set
            {
                _hundredsDaysBackImageSource = value;
                OnPropertyChanged("HundredsDaysBackImageSource");
            }
        }

        public ImageSource TensDaysFrontImageSource
        {
            get { return _tensDaysFrontImageSource; }
            set
            {
                _tensDaysFrontImageSource = value;
                OnPropertyChanged("TensDaysFrontImageSource");
            }
        }
        public ImageSource TensDaysBackImageSource
        {
            get { return _tensDaysBackImageSource; }
            set
            {
                _tensDaysBackImageSource = value;
                OnPropertyChanged("TensDaysBackImageSource");
            }
        }

        public ImageSource OnesDaysFrontImageSource
        {
            get { return _onesDaysFrontImageSource; }
            set
            {
                _onesDaysFrontImageSource = value;
                OnPropertyChanged("OnesDaysFrontImageSource");
            }
        }
        public ImageSource OnesDaysBackImageSource
        {
            get { return _onesDaysBackImageSource; }
            set
            {
                _onesDaysBackImageSource = value;
                OnPropertyChanged("OnesDaysBackImageSource");
            }
        }

        public ImageSource TensHoursFrontImageSource
        {
            get { return _tensHoursFrontImageSource; }
            set
            {
                _tensHoursFrontImageSource = value;
                OnPropertyChanged("TensHoursFrontImageSource");
            }
        }
        public ImageSource TensHoursBackImageSource
        {
            get { return _tensHoursBackImageSource; }
            set
            {
                _tensHoursBackImageSource = value;
                OnPropertyChanged("TensHoursBackImageSource");
            }
        }

        public ImageSource OnesHoursFrontImageSource
        {
            get { return _onesHoursFrontImageSource; }
            set
            {
                _onesHoursFrontImageSource = value;
                OnPropertyChanged("OnesHoursFrontImageSource");
            }
        }
        public ImageSource OnesHoursBackImageSource
        {
            get { return _onesHoursBackImageSource; }
            set
            {
                _onesHoursBackImageSource = value;
                OnPropertyChanged("OnesHoursBackImageSource");
            }
        }

        public ImageSource TensMinutesFrontImageSource
        {
            get { return _tensMinutesFrontImageSource; }
            set
            {
                _tensMinutesFrontImageSource = value;
                OnPropertyChanged("TensMinutesFrontImageSource");
            }
        }
        public ImageSource TensMinutesBackImageSource
        {
            get { return _tensMinutesBackImageSource; }
            set
            {
                _tensMinutesBackImageSource = value;
                OnPropertyChanged("TensMinutesBackImageSource");
            }
        }

        public ImageSource OnesMinutesFrontImageSource
        {
            get { return _onesMinutesFrontImageSource; }
            set
            {
                _onesMinutesFrontImageSource = value;
                OnPropertyChanged("OnesMinutesFrontImageSource");
            }
        }
        public ImageSource OnesMinutesBackImageSource
        {
            get { return _onesMinutesBackImageSource; }
            set
            {
                _onesMinutesBackImageSource = value;
                OnPropertyChanged("OnesMinutesBackImageSource");
            }
        }
        #endregion

        public TimerViewModel(NavigationStore navigationStore, TimeSpanModel model)
        {
            _timeSpan = model;
            _timeSpan.PropertyChanged += TimeSpan_TotalTimeSpanPropertyChanged;
            _imageSources = new ImageSources();
            NavigateCommand = new NavigateCommand<SettingViewModel>(navigationStore, () => new SettingViewModel(navigationStore, _timeSpan, this));
            SetDefaultFlipValue();
            if (_timeSpan.EndDate != null)
            {
                _timeSpan.StartCount();
                SetFlipValue(SelectTotalTimeSpan());
            }
        }

        private void TimeSpan_TotalTimeSpanPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_timeSpan.TotalTimeSpan))
            {
                SetFlipValue(SelectTotalTimeSpan());
                if (_timeSpan.TotalTimeSpan <= TimeSpan.Zero && _timeSpan.EndDate != null)
                {
                    MessageBox.Show($"Time is over at {_timeSpan.EndDate}", " ", MessageBoxButton.OK, MessageBoxImage.None, 
                        MessageBoxResult.None, MessageBoxOptions.ServiceNotification);
                }
            }
        }

        private void SetDefaultFlipValue()
        {
            _thousandsDaysFrontImageSource = _imageSources[0];
            _hundredsDaysFrontImageSource = _imageSources[0];
            _tensDaysFrontImageSource = _imageSources[0];
            _onesDaysFrontImageSource = _imageSources[0];

            _tensHoursFrontImageSource = _imageSources[0];
            _onesHoursFrontImageSource = _imageSources[0];
            _tensMinutesFrontImageSource = _imageSources[0];
            _onesMinutesFrontImageSource = _imageSources[0];
        }

        int onesMinutes, tensMinutes, onesHours, tensHours, onesDays, tensDays, hundredsDays, thousandsDays = 0;
        private void SetFlipValue(TimeSpan timeSpan)
        {
            SetOnesMinutes(timeSpan.Minutes);
            SetTensMinutes(timeSpan.Minutes);
            SetOnesHours(timeSpan.Hours);
            SetTensHours(timeSpan.Hours);
            SetOnesDays(timeSpan.Days);
            SetTensDays(timeSpan.Days);
            SetHundredsDays(timeSpan.Days);
            SetThousandsDays(timeSpan.Days);
        }

        private void SetOnesMinutes(int minutes)
        {
            if (minutes % 10 != onesMinutes)
            {
                onesMinutes = minutes % 10;
                OnesMinutesFrontImageSource = (onesMinutes == 9) ? _imageSources[0] : _imageSources[onesMinutes + 1];
                OnesMinutesBackImageSource = _imageSources[onesMinutes];
            }
        }

        private void SetTensMinutes(int minutes)
        {
            if (minutes / 10 != tensMinutes)
            {
                tensMinutes = minutes / 10;
                TensMinutesFrontImageSource = (tensMinutes == 5) ? _imageSources[0] : _imageSources[tensMinutes + 1];
                TensMinutesBackImageSource = _imageSources[tensMinutes];
            }
        }

        private void SetOnesHours(int hours)
        {
            if (hours % 10 != onesHours)
            {
                onesHours = hours % 10;
                if (hours / 10 < 2)
                    OnesHoursFrontImageSource = (onesHours == 9) ? _imageSources[0] : _imageSources[onesHours + 1];
                else
                    OnesHoursFrontImageSource = (onesHours == 3) ? _imageSources[0] : _imageSources[onesHours + 1];
                OnesHoursBackImageSource = _imageSources[onesHours];
            }
        }

        private void SetTensHours(int hours)
        {
            if (hours / 10 != tensHours)
            {
                tensHours = hours / 10;
                TensHoursFrontImageSource = (tensHours == 2) ? _imageSources[0] : _imageSources[tensHours + 1];
                TensHoursBackImageSource = _imageSources[tensHours];
            }
        }

        private void SetOnesDays(int days)
        {
            if (days % 10 != onesDays)
            {
                onesDays = days % 10;
                OnesDaysFrontImageSource = (onesDays == 9) ? _imageSources[0] : _imageSources[onesDays + 1];
                OnesDaysBackImageSource = _imageSources[onesDays];
            }
        }

        private void SetTensDays(int days)
        {
            if (days / 10 % 10 != tensDays)
            {
                tensDays = days / 10 % 10;
                TensDaysFrontImageSource = (tensDays == 9) ? _imageSources[0] : _imageSources[tensDays + 1];
                TensDaysBackImageSource = _imageSources[tensDays];
            }
        }

        private void SetHundredsDays(int days)
        {
            if (days / 100 % 10 != hundredsDays)
            {
                hundredsDays = days / 100 % 10;
                HundredsDaysFrontImageSource = (hundredsDays == 9) ? _imageSources[0] : _imageSources[hundredsDays + 1];
                HundredsDaysBackImageSource = _imageSources[hundredsDays];
            }
        }

        private void SetThousandsDays(int days)
        {
            if (days / 1000 != thousandsDays)
            {
                thousandsDays = days / 1000;
                ThousandsDaysFrontImageSource = (thousandsDays == 9) ? _imageSources[0] : _imageSources[thousandsDays + 1];
                ThousandsDaysBackImageSource = _imageSources[thousandsDays];
            }
        }

        private TimeSpan SelectTotalTimeSpan()
        {
            if (_timeSpan.TotalTimeSpan.Seconds != 0)
                return _timeSpan.TotalTimeSpan + TimeSpan.FromMinutes(1);
            else
                return _timeSpan.TotalTimeSpan;
        }

    }
}
