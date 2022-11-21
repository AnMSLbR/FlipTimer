using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace FlipTimer.Resources
{
    internal class Images
    {
        Image zero = new Image() { Source = new BitmapImage(new Uri("Resources/0.png", UriKind.Relative)) };
        Image one = new Image() { Source = new BitmapImage(new Uri("Resources/1.png", UriKind.Relative)) };
        Image two = new Image() { Source = new BitmapImage(new Uri("Resources/2.png", UriKind.Relative)) };
        Image three = new Image() { Source = new BitmapImage(new Uri("Resources/3.png", UriKind.Relative)) };
        Image four = new Image() { Source = new BitmapImage(new Uri("Resources/4.png", UriKind.Relative)) };
        Image five = new Image() { Source = new BitmapImage(new Uri("Resources/5.png", UriKind.Relative)) };
        Image six = new Image() { Source = new BitmapImage(new Uri("Resources/6.png", UriKind.Relative)) };
        Image seven = new Image() { Source = new BitmapImage(new Uri("Resources/7.png", UriKind.Relative)) };
        Image eight = new Image() { Source = new BitmapImage(new Uri("Resources/8.png", UriKind.Relative)) };
        Image nine = new Image() { Source = new BitmapImage(new Uri("Resources/9.png", UriKind.Relative)) };

        public Image this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return zero;
                    case 1: return one;
                    case 2: return two;
                    case 3: return three;
                    case 4: return four;
                    case 5: return five;
                    case 6: return six;
                    case 7: return seven;
                    case 8: return eight;
                    case 9: return nine;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
