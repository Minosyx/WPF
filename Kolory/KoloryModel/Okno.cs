using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KoloryModel
{
    public class Okno
    {
        private double x, y;
        private double width, height;
        public Okno(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public double X {  get; set; }
        public double Y {  get; set; }
        public double Width {  get; set; }
        public double Height {  get; set; }
    }
}
