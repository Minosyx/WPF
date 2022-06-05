using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Model;

namespace ZC2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void Btn_OnClick(object sender, RoutedEventArgs e)
        {
            if (ta.Text.Length != 0 && tb.Text.Length != 0 && tc.Text.Length != 0)
            {
                Quadratic q = new Quadratic(Double.Parse(ta.Text), Double.Parse(tb.Text), Double.Parse(tc.Text));
                if (q.X1 == null && q.X2 == null)
                {
                    tblock.Text = "Równanie nie ma rozwiązań rzeczywistych!";
                }
                else if (q.X1 == q.X2)

                {
                    tblock.Text = $"x0 = {q.X1}";
                }
                else tblock.Text = $"x1 = {q.X1}\nx2 = {q.X2}";
            }
        }
    }
}
