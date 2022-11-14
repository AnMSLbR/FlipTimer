using FlipTimer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipTimer.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel()
        {
            _navigationStore = new NavigationStore();
            _navigationStore.CurrentViewModel = new TimerViewModel(_navigationStore);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
