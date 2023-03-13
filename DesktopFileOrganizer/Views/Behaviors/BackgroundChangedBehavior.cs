using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace DesktopFileOrganizer.Views.Behaviors
{
    internal class BackgroundChangedBehavior:Behavior<Button>
    {

        /// <summary>
        /// 此行为用于切换黑暗模式
        /// </summary>
        public SolidColorBrush BgColor
        {
            get { return (SolidColorBrush)GetValue(BgColorProperty); }
            set { SetValue(BgColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BgColorProperty =
            DependencyProperty.Register("BgColor", typeof(SolidColorBrush), typeof(BackgroundChangedBehavior), new PropertyMetadata(default));

        public SolidColorBrush ForeColor
        {
            get { return (SolidColorBrush)GetValue(ForeColorProperty); }
            set { SetValue(ForeColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForeColorProperty =
            DependencyProperty.Register("ForeColor", typeof(SolidColorBrush), typeof(BackgroundChangedBehavior), new PropertyMetadata(default));



        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(BackgroundChangedBehavior), new PropertyMetadata(default));

        private ImageSource MornSource= new BitmapImage(new Uri(@"/Resources/Icons/sun.png", UriKind.RelativeOrAbsolute));
        private ImageSource NightSource= new BitmapImage(new Uri(@"/Resources/Icons/moon.png", UriKind.RelativeOrAbsolute));
        private SolidColorBrush White= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F2F3"));
        private SolidColorBrush Black= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        //bool 用于判断是否随时间进行切换黑暗模式
        private bool isAutoChanged = true;
        protected override void OnAttached()
        {
            ModeChanged();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimeTick);
            timer.Interval = TimeSpan.FromHours(1);
            timer.Start();
            AssociatedObject.Click += BtnClick;
        }

        private void BtnClick(object o,RoutedEventArgs args)
        {
            isAutoChanged = !isAutoChanged;
            BgColor=BgColor==White? Black : White;
            ForeColor=ForeColor==White? Black : White;
            if (ImgSource == MornSource)
                ImgSource = NightSource;
            else
                ImgSource = MornSource;
        }
        private void TimeTick(object o,EventArgs args)
        {
            ModeChanged();
        }

        private void ModeChanged()
        {
            if (isAutoChanged)
            {
                //如果时间在6~18点，就是正常模式，不在，则自动切换成黑暗模式
                if (DateTime.Now.Hour > 6 && DateTime.Now.Hour < 18)
                {
                    BgColor = White;
                    ForeColor = Black;
                    ImgSource = MornSource;
                }
                else
                {
                    BgColor = Black;
                    ForeColor = White;
                    ImgSource = NightSource;
                }
            }
        }

    }
}
