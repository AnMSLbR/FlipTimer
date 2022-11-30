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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FlipTimer.ViewModels
{
    internal class TimerViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }
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

        //public TimeSpan _box;
        //public TimeSpan Box
        //{
        //    get { return _box; }
        //    set
        //    {
        //        _box = value;
        //        OnPropertyChanged("Box");
        //    }
        //}

        public TimerViewModel(NavigationStore navigationStore, TimeSpanModel model)
        {
            _timeSpan = model;
            _timeSpan.PropertyChanged += TimeSpan_TotalTimeSpanPropertyChanged;
            _imageSources = new ImageSources();
            NavigateCommand = new NavigateCommand<SettingViewModel>(navigationStore, () => new SettingViewModel(navigationStore, _timeSpan, this));
            SetDefaultFlipValue();
        }

        private void TimeSpan_TotalTimeSpanPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_timeSpan.TotalTimeSpan))
            {
                //Box = _timeSpan.TotalTimeSpan;
                SetFlipValue();
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

        int onesMinutes = 0;
        int tensMinutes = 0;
        int onesHours = 0;
        int tensHours = 0;
        int onesDays = 0;
        int tensDays = 0;
        int hundredsDays = 0;
        int thousandsDays = 0;
        private void SetFlipValue()
        {
            SetOnesMinutes();
            SetTensMinutes();
            SetOnesHours();
            SetTensHours();
            SetOnesDays();
            SetTensDays();
            SetHundredsDays();
            SetThousandsDays();
        }

        private void SetOnesMinutes()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Minutes) % 10) != onesMinutes)
            {
                onesMinutes = Convert.ToInt32(_timeSpan.TotalTimeSpan.Minutes) % 10;
                OnesMinutesFrontImageSource = (onesMinutes == 9) ? _imageSources[0] : _imageSources[onesMinutes + 1];
                OnesMinutesBackImageSource = _imageSources[onesMinutes];
            }
        }

        private void SetTensMinutes()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Minutes) / 10) != tensMinutes)
            {
                tensMinutes = Convert.ToInt32(_timeSpan.TotalTimeSpan.Minutes) / 10;
                TensMinutesFrontImageSource = (tensMinutes == 5) ? _imageSources[0] : _imageSources[tensMinutes + 1];
                TensMinutesBackImageSource = _imageSources[tensMinutes];
            }
        }

        private void SetOnesHours()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Hours) % 10) != onesHours)
            {
                onesHours = Convert.ToInt32(_timeSpan.TotalTimeSpan.Hours) % 10;
                if (Convert.ToInt32(_timeSpan.TotalTimeSpan.Hours) / 10 == 0)
                    OnesHoursFrontImageSource = (onesHours == 9) ? _imageSources[0] : _imageSources[onesHours + 1];
                else
                    OnesHoursFrontImageSource = (onesHours == 3) ? _imageSources[0] : _imageSources[onesHours + 1];
                OnesHoursBackImageSource = _imageSources[onesHours];
            }
        }

        private void SetTensHours()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Hours) / 10) != tensHours)
            {
                tensHours = Convert.ToInt32(_timeSpan.TotalTimeSpan.Hours) / 10;
                TensHoursFrontImageSource = (tensHours == 2) ? _imageSources[0] : _imageSources[tensHours + 1];
                TensHoursBackImageSource = _imageSources[tensHours];
            }
        }

        private void SetOnesDays()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) % 10) != onesDays)
            {
                onesDays = Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) % 10;
                OnesDaysFrontImageSource = (onesDays == 9) ? _imageSources[0] : _imageSources[onesDays + 1];
                OnesDaysBackImageSource = _imageSources[onesDays];
            }
        }

        private void SetTensDays()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) / 10 % 10) != tensDays)
            {
                tensDays = Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) / 10 % 10;
                TensDaysFrontImageSource = (tensDays == 9) ? _imageSources[0] : _imageSources[tensDays + 1];
                TensDaysBackImageSource = _imageSources[tensDays];
            }
        }

        private void SetHundredsDays()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) / 100 % 10) != hundredsDays)
            {
                hundredsDays = Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) / 100 % 10;
                HundredsDaysFrontImageSource = (hundredsDays == 9) ? _imageSources[0] : _imageSources[hundredsDays + 1];
                HundredsDaysBackImageSource = _imageSources[hundredsDays];
            }
        }

        private void SetThousandsDays()
        {
            if ((Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) / 1000) != thousandsDays)
            {
                thousandsDays = Convert.ToInt32(_timeSpan.TotalTimeSpan.Days) / 1000;
                ThousandsDaysFrontImageSource = (thousandsDays == 9) ? _imageSources[0] : _imageSources[thousandsDays + 1];
                ThousandsDaysBackImageSource = _imageSources[thousandsDays];
            }
        }

    }
}
