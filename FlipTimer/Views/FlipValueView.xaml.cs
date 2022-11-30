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

        public static readonly DependencyProperty FrontImageSourceProperty = DependencyProperty.Register("FrontImageSource", typeof(ImageSource), typeof(FlipValueView));
        public static readonly DependencyProperty BackImageSourceProperty = DependencyProperty.Register("BackImageSource", typeof(ImageSource), typeof(FlipValueView));

        DependencyPropertyDescriptor FrontImageSourcePropertyDescriptor = DependencyPropertyDescriptor.FromProperty(FrontImageSourceProperty, typeof(FlipValueView));
        DependencyPropertyDescriptor BackImageSourcePropertyDescriptor = DependencyPropertyDescriptor.FromProperty(BackImageSourceProperty, typeof(FlipValueView));

        public ImageSource FrontImageSource
        {
            get { return (ImageSource)GetValue(FrontImageSourceProperty); }
            set { SetValue(FrontImageSourceProperty, value); }
        }

        public ImageSource BackImageSource
        {
            get { return (ImageSource)GetValue(BackImageSourceProperty); }
            set { SetValue(BackImageSourceProperty, value); }
        }

        DoubleAnimation outAnimation = null;
        DoubleAnimation inAnimation = null;

        public FlipValueView()
        {
            InitializeComponent();
            
            FrontImageSourcePropertyDescriptor?.AddValueChanged(this, delegate
            {
                    SetFrontImageSource(FrontImageSource);
            });

            BackImageSourcePropertyDescriptor?.AddValueChanged(this, delegate
            {
                SetBackImageSource(BackImageSource);
                FlipElement(frontBorder, backBorder);
            });

            backBorder.RenderTransform = new ScaleTransform(1, 0);
            outAnimation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(480));
            inAnimation = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(480));
            inAnimation.BeginTime = TimeSpan.FromMilliseconds(480);
        }

        public void SetFrontImageSource(ImageSource frontImageSouce)
        {
            backImage.Source = null;
            frontImage.Source = frontImageSouce;
        }

        public void SetBackImageSource(ImageSource backImageSource)
        {
            backImage.Source = backImageSource;
        }

        private void FlipElement(UIElement front, UIElement back)
        {
            if ((front == null) || (back == null)) return;

            Storyboard sbFlip = new Storyboard();
            Storyboard.SetTargetProperty(sbFlip, new PropertyPath("(UIElement.RenderTransform).(ScaleTransform.ScaleY)"));

            front.RenderTransform = new ScaleTransform(1, 1);
            back.RenderTransform = new ScaleTransform(1, 0);

            Storyboard.SetTargetName(outAnimation, (front as FrameworkElement).Name);
            Storyboard.SetTargetName(inAnimation, (back as FrameworkElement).Name);

            sbFlip.Children.Add(outAnimation);
            sbFlip.Children.Add(inAnimation);

            sbFlip.Begin(this);
        }

    }
}
