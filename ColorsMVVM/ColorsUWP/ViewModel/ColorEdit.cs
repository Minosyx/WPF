using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media;
using Windows.UI;

namespace ColorsMVVM.ViewModel
{
    using Model;
    public class ColorEdit : ObservedObject
    {
        private MColor model = new MColor(0, 0, 0);
        private ICommand reset;

        public byte R
        {
            get => model.R;
            set
            {
                model.R = value;
                onPropertyChanged(nameof(R));
                onPropertyChanged(nameof(R), nameof(Kolor));
            }
        }

        public byte G
        {
            get => model.G;
            set
            {
                model.G = value;
                onPropertyChanged(nameof(G));
                onPropertyChanged(nameof(G), nameof(Kolor));
            }
        }

        public byte B
        {
            get => model.B;
            set
            {
                model.B = value;
                onPropertyChanged(nameof(B));
                onPropertyChanged(nameof(B), nameof(Kolor));
            }
        }

        public Color Kolor => Color.FromArgb(255, model.R, model.G, model.B);

        public ICommand Reset
        {
            get
            {
                if (reset == null)
                    reset = new RelayCommand(
                        (object o) =>
                        {
                            model.Reset();
                            onPropertyChanged(nameof(R), nameof(G), nameof(B));
                        });
                //(object o) => model.R != 0 || model.G != 0 || model.B != 0);
                return reset;
            }
        }
    }
}
