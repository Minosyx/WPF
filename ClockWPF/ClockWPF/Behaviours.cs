using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace ClockWPF
{
    public class WindowMove : Behavior<Window>
    {
        protected override void OnAttached()
        {
            Window window = AssociatedObject;
            if (window != null)
            {
                window.MouseDown += window_MouseDown;
                window.MouseMove += window_MouseMove;
                window.MouseUp += window_MouseUp;
            }
        }

        private bool moving = false;
        private Point startCursor;
        private void window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window window = (Window) sender;
            if (!moving && e.LeftButton == MouseButtonState.Pressed)
            {
                moving = true;
                startCursor = e.GetPosition(window);
                Mouse.OverrideCursor = Cursors.Hand;
            }
        }

        private void window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Window window = (Window)sender;
            if (moving)
            {
                Point cursorPos = e.GetPosition(window);
                Vector shift = cursorPos - startCursor;
                window.Left += shift.X;
                window.Top += shift.Y;
            }
        }

        private void window_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window window = (Window)sender;
            if (moving && e.LeftButton == MouseButtonState.Released)
            {
                moving = false;
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }
    }
}
