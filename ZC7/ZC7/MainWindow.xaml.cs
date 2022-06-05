using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ZC7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if ((e.Source as Button).ActualWidth < 50 && (e.Source as Button).ActualHeight < 50)
            {
                (e.Source as Button).Background = new SolidColorBrush(Colors.Red);
                return;
            }
            Button btn = new Button();
            (e.Source as Button).HorizontalContentAlignment = HorizontalAlignment.Stretch;
            (e.Source as Button).VerticalContentAlignment = VerticalAlignment.Stretch;
            btn.Margin = new Thickness(10);
            btn.Click += ButtonBase_OnClick;
            (e.Source as Button).Content = btn;
        }
    }
}
