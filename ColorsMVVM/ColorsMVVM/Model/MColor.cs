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
        //public byte R, G, B;
        private byte r, g, b;

        public MColor(byte r, byte g, byte b)
        {
            //R = r;
            //G = g;
            //B = b;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public byte R
        {
            get => this.r;
            set => this.r = value;
        }

        public byte G
        {
            get => this.g;
            set => this.g = value;
        }

        public byte B
        {
            get => this.b;
            set => this.b = value;
        }

        public void Reset()
        {
            R = 0;
            G = 0;
            B = 0;
        }
    }
}
