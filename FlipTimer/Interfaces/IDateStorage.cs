using FlipTimer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipTimer.Interfaces
{
    internal interface IDateStorage
    {
        Task WriteAsync(TimeSpanModel timeSpanModel, string fileName);
        TimeSpanModel Read(string fileName);
    }
}
