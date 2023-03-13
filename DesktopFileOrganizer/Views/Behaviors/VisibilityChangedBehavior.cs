using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DesktopFileOrganizer.Views.Behaviors
{
    internal class VisibilityChangedBehavior:Behavior<Button>
    {
        public Visibility MyVisibility
        {
            get { return (Visibility)GetValue(MyVisibilityProperty); }
            set { SetValue(MyVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MenuVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyVisibilityProperty =
            DependencyProperty.Register("MyVisibility", typeof(Visibility), typeof(VisibilityChangedBehavior), new PropertyMetadata(default));

        protected override void OnAttached()
        {
            base.OnAttached();
            MyVisibility = Visibility.Collapsed;
            AssociatedObject.Click += delegate 
            {
                MyVisibility = MyVisibility==Visibility.Visible?Visibility.Collapsed:Visibility.Visible;
            };
        }
    }
}
