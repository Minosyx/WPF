using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using KoloryModel.Properties;

namespace KoloryModel
{
    public static class Ustawienia
    {
        public static Color CzytajKolor()
        {
            Settings ustawienia = Settings.Default;
            Color kolor = new Color()
            {
                A = 255,
                R = ustawienia.R,
                G = ustawienia.G,
                B = ustawienia.B
            };
            return kolor;
        }

        public static Okno CzytajOkno()
        {
            Settings ustawienia = Settings.Default;
            return new Okno(ustawienia.x, ustawienia.y, ustawienia.width, ustawienia.height);
        }

        public static void Zapisz(Color kolor, double x, double y, double width, double height)
        {
            Settings ustawienia = Settings.Default;
            ustawienia.R = kolor.R;
            ustawienia.G = kolor.G;
            ustawienia.B = kolor.B;
            ustawienia.x = x;
            ustawienia.y = y;
            ustawienia.width = width;
            ustawienia.height = height;
            ustawienia.Save();
        }
    }
}
