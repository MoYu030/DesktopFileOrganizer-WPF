using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DesktopFileOrganizer.Views.Behaviors
{
    internal class TopmostBtnBehavior:Behavior<Button>
    {

        /// <summary>
        /// 此行为用于控制TopMost置顶功能的开启，以及置顶图标的显示与否
        /// </summary>

        public bool IsTopmost
        {
            get { return (bool)GetValue(IsTopmostProperty); }
            set { SetValue(IsTopmostProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsTopmostProperty =
            DependencyProperty.Register("IsTopmost", typeof(bool), typeof(TopmostBtnBehavior), new PropertyMetadata(default));

        public Visibility BorderVisibility
        {
            get { return (Visibility)GetValue(BorderVisibilityProperty); }
            set { SetValue(BorderVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderVisibilityProperty =
            DependencyProperty.Register("BorderVisibility", typeof(Visibility), typeof(TopmostBtnBehavior), new PropertyMetadata(default));



        protected override void OnAttached()
        {
            BorderVisibility=Visibility.Collapsed;
            base.OnAttached();
            AssociatedObject.Click += BtnClick;

        }

        private void BtnClick(object o,RoutedEventArgs args)
        {
            
            IsTopmost = !IsTopmost;
            BorderVisibility = BorderVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
