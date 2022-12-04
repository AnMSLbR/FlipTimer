using FlipTimer.Interfaces;
using FlipTimer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlipTimer.Services
{
    internal class DateStorageJson : IDateStorage
    {
        private TimeSpanModel _timeSpanModel;
        //public DateStorageJson(TimeSpanModel timeSpanModel)
        //{
        //    this._timeSpanModel = timeSpanModel;
        //}
        public TimeSpanModel Read(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task WriteAsync(TimeSpanModel timeSpan, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                await JsonSerializer.SerializeAsync<TimeSpanModel>(fs, timeSpan);
            }
        }
    }
}
