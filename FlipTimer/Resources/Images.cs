using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace FlipTimer.Resources
{
    internal class ImageSources
    {
        ImageSource zero;
        ImageSource one;
        ImageSource two;
        ImageSource three;
        ImageSource four;
        ImageSource five;
        ImageSource six;
        ImageSource seven;
        ImageSource eight;
        ImageSource nine;

        public ImageSource this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return zero = new BitmapImage(new Uri("../Resources/0.png", UriKind.Relative));
                    case 1: return one = new BitmapImage(new Uri("../Resources/1.png", UriKind.Relative));
                    case 2: return two = new BitmapImage(new Uri("../Resources/2.png", UriKind.Relative));
                    case 3: return three = new BitmapImage(new Uri("../Resources/3.png", UriKind.Relative));
                    case 4: return four = new BitmapImage(new Uri("../Resources/4.png", UriKind.Relative));
                    case 5: return five = new BitmapImage(new Uri("../Resources/5.png", UriKind.Relative));
                    case 6: return six = new BitmapImage(new Uri("../Resources/6.png", UriKind.Relative));
                    case 7: return seven = new BitmapImage(new Uri("../Resources/7.png", UriKind.Relative));
                    case 8: return eight = new BitmapImage(new Uri("../Resources/8.png", UriKind.Relative));
                    case 9: return nine = new BitmapImage(new Uri("../Resources/9.png", UriKind.Relative));
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
