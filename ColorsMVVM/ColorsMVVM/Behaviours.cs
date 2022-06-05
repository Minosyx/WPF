using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.Xaml.Behaviors;

namespace ColorsMVVM
{
    public class KeyDownWindowClose : Behavior<Window>
    {
        public Key Klawisz { get; set; }

        protected override void OnAttached()
        {
            Window window = AssociatedObject;
            if (window != null)
                window.PreviewKeyDown += window_PreviewKeyDown;
        }

        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Window window = sender as Window;
            if (e.Key == Klawisz)
                window.Close();
        }
    }

    public class KeyClosingWindow : Behavior<Window>
    {
        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(
            "Key",
            typeof(Button),
            typeof(KeyClosingWindow),
            new PropertyMetadata(null, keyChanged));

        public Button Key
        {
            get => (Button)GetValue(KeyProperty);
            set => SetValue(KeyProperty, value);
        }

        private static void keyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = (d as KeyClosingWindow).AssociatedObject;
            RoutedEventHandler buttonClick = (object sender, RoutedEventArgs args) => window.Close();
            if (e.OldValue != null) ((Button)e.OldValue).Click -= buttonClick;
            if (e.NewValue != null) ((Button)e.NewValue).Click += buttonClick;
        }
    }

    public static class KeyCloseBehavior
    {
        public static Key GetKey(DependencyObject d)
        {
            return (Key) d.GetValue(KeyProperty);
        }

        public static void SetKey(DependencyObject d, Key value)
        {
            d.SetValue(KeyProperty, value);
        }

        public static readonly DependencyProperty KeyProperty = DependencyProperty.RegisterAttached(
            "Key",
            typeof(Key),
            typeof(KeyCloseBehavior),
            new PropertyMetadata(Key.None, keyChanged));

        //private static void keyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    Key key = (Key) e.NewValue;
        //    if (d is Window)
        //        (d as Window).PreviewKeyDown += ((sender, args) =>
        //        {
        //            if (args.Key == key)
        //                (d as Window).Close();
        //        });
        //    else
        //    {
        //        (d as UIElement).PreviewKeyDown += ((sender, args) =>
        //        {
        //            if (args.Key == key)
        //                (d as UIElement).IsEnabled = false;
        //        });
        //    }
        //}

        private static void keyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Key key = (Key) e.NewValue;
            switch(d)
            {
                case Window window:
                    window.PreviewKeyDown += (sender, args) =>
                    {
                        if (args.Key == key) window.Close();
                    };
                    break;
                case UIElement uie: 
                    uie.PreviewKeyDown += (sender, args) =>
                    {
                        if (args.Key == key) uie.IsEnabled = false;
                    };
                    break;
            };
        }
    }
}
