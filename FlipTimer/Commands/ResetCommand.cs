using FlipTimer.Interfaces;
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
        private IDateStorage _dateStorage;
        private string _fileName;
        public ResetCommand(TimeSpanModel timeSpan, IDateStorage dateStorage, string fileName)
        {
            this._timeSpan = timeSpan;
            this._dateStorage = dateStorage;
            this._fileName = fileName;
        }
        public override void Execute(object? parameter)
        {
            _timeSpan.ResetTimer();
            _dateStorage.WriteAsync(_timeSpan, _fileName);
        }
    }
}
