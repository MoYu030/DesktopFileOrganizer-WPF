using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DesktopFileOrganizer.Views.Behaviors
{
    internal class UpdateTimeBehavior:Behavior<TextBlock>
    {

        /// <summary>
        /// 此行为用于实时更新时间，timer.Interval 设计为10秒，为后期加入提醒待办事项做准备
        /// </summary>
        public string NowTime
        {
            get { return (string)GetValue(NowTimeProperty); }
            set { SetValue(NowTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NowTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NowTimeProperty =
            DependencyProperty.Register("NowTime", typeof(string), typeof(UpdateTimeBehavior), new FrameworkPropertyMetadata(default,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        protected override void OnAttached()
        {
            base.OnAttached();
            NowTime = DateTime.Now.ToString("MM月dd日 HH:mm");
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimeTick);
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Start();
        }

        private void TimeTick(object sender, EventArgs e)
        {
            NowTime = DateTime.Now.ToString("MM月dd日 HH:mm");
        }
    }
}
