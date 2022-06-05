using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stoper
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Stoper"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Stoper;assembly=Stoper"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class Counter : Button
    {
        public static readonly DependencyProperty MinutesProperty =
            DependencyProperty.Register("Minutes", typeof(int), typeof(Counter), new PropertyMetadata(10));
        public static readonly DependencyProperty SecondsProperty =
            DependencyProperty.Register("Seconds", typeof(int), typeof(Counter), new PropertyMetadata(0));

        private (int minutes, int seconds) time;
        private bool isStopped = false;
        private bool isRunning = false;

        public int Minutes
        {
            get => (int)GetValue(MinutesProperty);
            set => SetValue(MinutesProperty, value);
        }

        public int Seconds
        {
            get => (int)GetValue(SecondsProperty);
            set => SetValue(SecondsProperty, value);
        }

        static Counter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Counter), new FrameworkPropertyMetadata(typeof(Counter)));
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            switch (isRunning)
            {
                case false:
                    _StartCountdown();
                    break;
                case true:
                    isStopped = true;
                    break;
            }
        }

        private async void _StartCountdown()
        {
            isRunning = true;
            isStopped = false;
            time = (Minutes, Seconds);

            while (!isStopped && time.minutes * 60 + time.seconds > 0)
            {
                _ContentUpdate();
                await Task.Delay(1000);
                if (time.seconds == 0)
                {
                    time.minutes--;
                    time.seconds = 59;
                }
                else
                {
                    time.seconds--;
                }
            }

            isRunning = false;
        }

        private void _ContentUpdate()
        {
            this.Content = $"{time.minutes}:{time.seconds:D2}";
        }
    }
}
