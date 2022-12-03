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
    internal class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private TimeSpanModel _timeSpan;
        public ICommand ResetCommand { get; }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            _timeSpan = new TimeSpanModel();
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = new TimerViewModel(_navigationStore, _timeSpan);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            NavigateCommand = CurrentViewModel.NavigateCommand;
            ResetCommand = new ResetCommand(_timeSpan);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
