using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Choinka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ikonaWZasobniku = new IkonaWZasobniku(this);
        }

        private IkonaWZasobniku ikonaWZasobniku;
        private bool zakonczonaAnimacjaZnikania = false;

        #region Przenoszenie okna
        private bool czyPrzenoszenie = false;
        private Cursor kursor;
        private Point punktPoczatkowy;
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == Mouse.LeftButton)
            {
                czyPrzenoszenie = true;
                kursor = this.Cursor;
                Cursor = Cursors.Hand;
                punktPoczatkowy = e.GetPosition(this);
            }
        }

        private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (czyPrzenoszenie)
            {
                Vector przesuniecie = e.GetPosition(this) - punktPoczatkowy;
                Left += przesuniecie.X;
                Top += przesuniecie.Y;
            }
        }

        private void MainWindow_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (czyPrzenoszenie)
            {
                Cursor = kursor;
                czyPrzenoszenie = false;
            }
        }

        #endregion

        private void MainWindow_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) this.Close();
        }

        private void Storyboard_Completed(object? sender, EventArgs e)
        {
            zakonczonaAnimacjaZnikania = true;
            ikonaWZasobniku.Dispose();
            Close();
        }

        private void MainWindow_OnClosing(object? sender, CancelEventArgs e)
        {
            if (!zakonczonaAnimacjaZnikania)
            {
                Storyboard scenorysZnikaniaOkna = this.Resources["scenorysZamykaniaOkna"] as Storyboard;
                scenorysZnikaniaOkna.Begin();
                e.Cancel = true;
            }
        }
    }
}
