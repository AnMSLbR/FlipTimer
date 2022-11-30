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
        ImageSource zero = new BitmapImage(new Uri("../Resources/0.png", UriKind.Relative));
        ImageSource one = new BitmapImage(new Uri("../Resources/1.png", UriKind.Relative));
        ImageSource two = new BitmapImage(new Uri("../Resources/2.png", UriKind.Relative));
        ImageSource three = new BitmapImage(new Uri("../Resources/3.png", UriKind.Relative));
        ImageSource four = new BitmapImage(new Uri("../Resources/4.png", UriKind.Relative));
        ImageSource five = new BitmapImage(new Uri("../Resources/5.png", UriKind.Relative));
        ImageSource six = new BitmapImage(new Uri("../Resources/6.png", UriKind.Relative));
        ImageSource seven = new BitmapImage(new Uri("../Resources/7.png", UriKind.Relative));
        ImageSource eight = new BitmapImage(new Uri("../Resources/8.png", UriKind.Relative));
        ImageSource nine = new BitmapImage(new Uri("../Resources/9.png", UriKind.Relative));

        public ImageSource this[int index]
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
