using FlipTimer.Commands;
using FlipTimer.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlipTimer.ViewModels
{
    internal class TimerViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; }

        public TimerViewModel(NavigationStore navigationStore)
        {
            NavigateCommand = new NavigateCommand<SettingViewModel>(navigationStore, () => new SettingViewModel(navigationStore));
        }
    }
}
