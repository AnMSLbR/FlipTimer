using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlipTimer.Views
{
    public partial class FlipValueView : UserControl
    {

        public static readonly DependencyProperty FrontImageProperty = DependencyProperty.Register("FrontImage", typeof(Image), typeof(FlipValueView));
        public static readonly DependencyProperty BackImageProperty = DependencyProperty.Register("BackImage", typeof(Image), typeof(FlipValueView));

        DependencyPropertyDescriptor FrontImagePropertyDescriptor = DependencyPropertyDescriptor.FromProperty(FrontImageProperty, typeof(FlipValueView));
        DependencyPropertyDescriptor BackImagePropertyDescriptor = DependencyPropertyDescriptor.FromProperty(BackImageProperty, typeof(FlipValueView));

        public Image FrontImage
        {
            get { return (Image)GetValue(FrontImageProperty); }
            set { SetValue(FrontImageProperty, value); }
        }

        public Image BackImage
        {
            get { return (Image)GetValue(BackImageProperty); }
            set { SetValue(BackImageProperty, value); }
        }

        private bool flipFlag = true;

        DoubleAnimation outAnimation = null;
        DoubleAnimation inAnimation = null;

        public FlipValueView()
        {
            InitializeComponent();

            FrontImagePropertyDescriptor?.AddValueChanged(this, delegate
            {
                SetFrontImage(FrontImage);
            });

            BackImagePropertyDescriptor?.AddValueChanged(this, delegate
            {
                SetBackImage(BackImage);
                Flip();
            });

            backSide.RenderTransform = new ScaleTransform(1, 0);
            outAnimation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(500));
            inAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(500));
            inAnimation.BeginTime = TimeSpan.FromMilliseconds(500);
        }

        public void SetFrontImage(UIElement frontImage)
        {
            frontSide.Child = frontImage;
        }

        public void SetBackImage(UIElement backImage)
        {
            backSide.Child = backImage;
        }

        private void FlipImage(UIElement frontImage, UIElement backImage)
        {
            if ((frontImage == null) || (backImage == null)) return;

            Storyboard sbFlip = new Storyboard();
            Storyboard.SetTargetProperty(sbFlip, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            frontImage.RenderTransform = new ScaleTransform(1, 1);
            backImage.RenderTransform = new ScaleTransform(1, 0);

            Storyboard.SetTargetName(outAnimation, (frontImage as FrameworkElement).Name);
            Storyboard.SetTargetName(inAnimation, (backImage as FrameworkElement).Name);

            sbFlip.Children.Add(outAnimation);
            sbFlip.Children.Add(inAnimation);

            sbFlip.Begin(this);
        }

        public void Flip()
        {
            if (!flipFlag)
                FlipImage(backSide, frontSide);
            else
                FlipImage(frontSide, backSide);
            flipFlag = !flipFlag;
        }

    }
}
