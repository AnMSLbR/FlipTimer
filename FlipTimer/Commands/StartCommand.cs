using FlipTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlipTimer.Commands
{
    internal class StartCommand : CommandBase
    {
        private TimeSpanModel _timeSpan;
        public StartCommand(TimeSpanModel timeSpan)
        {
            this._timeSpan = timeSpan;
        }

        public override void Execute(object? isChecked)
        {
            if ((bool)isChecked!)
                _timeSpan.ResetTimeSpan(false);
            _timeSpan.StartCount();
        }
    }
}
