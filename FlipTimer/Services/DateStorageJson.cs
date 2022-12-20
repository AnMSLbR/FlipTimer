using FlipTimer.Interfaces;
using FlipTimer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace FlipTimer.Services
{
    internal class DateStorageJson : IDateStorage
    {
        public TimeSpanModel Read(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    return JsonSerializer.Deserialize<TimeSpanModel>(fs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load the time span.\r\n{ex.Message}");
                return new TimeSpanModel();
            }
        }

        public async Task WriteAsync(TimeSpanModel timeSpan, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync<TimeSpanModel>(fs, timeSpan);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save the time span.\r\n{ex.Message}");
            }
        }
    }
}
