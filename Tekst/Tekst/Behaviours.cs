using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using System.Windows.Input;

namespace Tekst
{
    public class Beep : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.TextChanged += textBox_TextChanged;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SystemSounds.Beep.Play();
        }
    }
}
