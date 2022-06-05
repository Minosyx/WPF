using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsMVVM.Model
{
    public static class Settings_Mock
    {
        public static byte r = 0;
        public static byte g = 128;
        public static byte b = 255;
        public static MColor Read()
        {
            return new MColor(r, g, b);
        }
        public static void Save(this MColor kolor)
        {
            r = kolor.R;
            g = kolor.G;
            b = kolor.B;
        }
    }
}
