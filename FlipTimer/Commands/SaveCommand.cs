using FlipTimer.Interfaces;
using FlipTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipTimer.Commands
{
    internal class SaveCommand : CommandBase
    {
        private TimeSpanModel _timeSpanModel;
        private IDateStorage _dateStorage;
        private string _fileName;

        public SaveCommand(TimeSpanModel timeSpanModel, IDateStorage dateStorage, string fileName)
        {
            this._timeSpanModel = timeSpanModel;
            this._dateStorage = dateStorage;
            this._fileName = fileName;
        }

        public override void Execute(object? parameter)
        {
            if(_timeSpanModel.IsTimerRunning)
                _dateStorage.WriteAsync(_timeSpanModel, _fileName);
        }
    }
}
