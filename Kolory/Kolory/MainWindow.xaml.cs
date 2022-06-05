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
using KoloryModel;

namespace Kolory
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Okno o = Ustawienia.CzytajOkno();
            Color kolor = Ustawienia.CzytajKolor();
            Left = o.X;
            Top = o.Y;
            Width = o.Width;
            Height = o.Height;
            rectangle.Fill = new SolidColorBrush(kolor);
            //Sliders_OnValueChanged(null, null);
            sliderR.Value = kolor.R;
            sliderG.Value = kolor.G;
            sliderB.Value = kolor.B;
            textR.Text = ((int)kolor.R).ToString();
            textG.Text = ((int)kolor.G).ToString();
            textB.Text = ((int)kolor.B).ToString();
        }
        private void Sliders_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //rectangle.Fill = Brushes.BlueViolet;
            Color kolor = Color.FromRgb(
                (byte)sliderR.Value,
                (byte)sliderG.Value,
                (byte)sliderB.Value);
            KolorProstokata = kolor;
            textR.Text = ((int)sliderR.Value).ToString();
            textG.Text = ((int)sliderG.Value).ToString();
            textB.Text = ((int)sliderB.Value).ToString();
            //rectangle.Fill = new SolidColorBrush(kolor);
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }

        private Color KolorProstokata
        {
            get => (rectangle.Fill as SolidColorBrush).Color;
            set => (rectangle.Fill as SolidColorBrush).Color = value;
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            Ustawienia.Zapisz(KolorProstokata, Left, Top, Width, Height);
        }
    }
}
