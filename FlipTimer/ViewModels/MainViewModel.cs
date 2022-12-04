using FlipTimer.Commands;
using FlipTimer.Interfaces;
using FlipTimer.Models;
using FlipTimer.Services;
using FlipTimer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlipTimer.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private TimeSpanModel _timeSpan;
        private IDateStorage _dateStorage;
        private readonly string _fileName = "TimeSpan.json";
        public ICommand ResetCommand { get; }
        public ICommand SaveCommand { get; }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            _timeSpan = new TimeSpanModel();
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = new TimerViewModel(_navigationStore, _timeSpan);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            _dateStorage = new DateStorageJson();
            SaveCommand = new SaveCommand(_timeSpan, _dateStorage, _fileName);

            NavigateCommand = CurrentViewModel.NavigateCommand;
            ResetCommand = new ResetCommand(_timeSpan);

        }

        private void LoadTimeSpanFromFile()
        {
            _timeSpan = _dateStorage.Read(_fileName);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
