using FlipTimer.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipTimer.Commands
{
    internal class ResetCommand : CommandBase
    {
        private TimeSpanModel _timeSpan;
        public ResetCommand(TimeSpanModel timeSpan)
        {
            this._timeSpan = timeSpan;
        }
        public override void Execute(object? parameter)
        {
            _timeSpan.ResetTimer();
        }
    }
}
