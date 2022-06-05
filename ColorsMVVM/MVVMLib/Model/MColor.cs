using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ColorsMVVM.Model
{
    public class MColor
    {
        public byte R, G, B;

        public MColor(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public void Reset()
        {
            R = 0;
            G = 0;
            B = 0;
        }
    }
}
