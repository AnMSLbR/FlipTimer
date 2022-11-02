using FlipTimer.Commands;
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
        public ICommand NavigateCommand { get; }

        public SettingViewModel(NavigationStore navigationStore)
        {
            NavigateCommand = new NavigateCommand<TimerViewModel>(navigationStore, () => new TimerViewModel(navigationStore));
        }
    }
}
