using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Quadratic
    {
        private double a, b, c;
        public Quadratic(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            Calculate();
        }

        private void Calculate()
        {
            double delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                X1 = (-b - Math.Sqrt(delta)) / (2 * a);
                X2 = (-b + Math.Sqrt(delta)) / (2 * a);
            }

            if (delta == 0)
            {
                X1 = -b / (2 * a);
                X2 = X1;
            }
        }

        public double? X1 { get; private set; }
        public double? X2 { get; private set; }
    }
}
