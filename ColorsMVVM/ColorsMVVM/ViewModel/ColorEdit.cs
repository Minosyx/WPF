using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace ColorsMVVM.ViewModel
{
    using Model;
    public class ColorEdit : ObservedObject
    {
        //private MColor model = Settings.Read();
        private MColor model;
        private ICommand reset;
        private bool useMock;

        public ColorEdit()
        {
            model = Settings.Read();
        }

        public ColorEdit(bool useMock = false)
        {
            this.useMock = useMock;
            if (!useMock) model = Settings.Read();
            else model = Settings_Mock.Read();
        }


        public byte R
        {
            get => model.R;
            set
            {
                model.R = value;
                onPropertyChanged(nameof(R));
                //onPropertyChanged(nameof(R), nameof(Kolor));
            }
        }

        public byte G
        {
            get => model.G;
            set
            {
                model.G = value;
                onPropertyChanged(nameof(G));
                //onPropertyChanged(nameof(G), nameof(Kolor));
            }
        }

        public byte B
        {
            get => model.B;
            set
            {
                model.B = value;
                onPropertyChanged(nameof(B));
                //onPropertyChanged(nameof(B), nameof(Kolor));
            }
        }

        //public Color Kolor => Color.FromRgb(model.R, model.G, model.B);

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
                        },
                        (object o) => model.R != 0 || model.G != 0 || model.B != 0);
                return reset;
            }
        }

        public void _Save()
        {
            //model.Save();
            if (!useMock)
                Settings.Save(model);
            else
                Settings_Mock.Save(model);
        }

        public ICommand Zapisz => new RelayCommand(o => _Save());
    }
}
