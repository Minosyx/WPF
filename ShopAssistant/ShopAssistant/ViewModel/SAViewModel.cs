using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopAssistant.ViewModel
{
    using Model;
    public class SAViewModel : INotifyPropertyChanged
    {
        private SAModel model = new(7000);

        public event PropertyChangedEventHandler? PropertyChanged;

        private ICommand dodajKwote;

        public decimal Suma => model.Suma;

        protected void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand DodajKwote
        {
            get
            {
                if (dodajKwote == null)
                    dodajKwote = new RelayCommand(
                        (object o) =>
                        {
                            decimal kwota = decimal.Parse((string) o);
                            model.Dodaj(kwota);
                            onPropertyChanged(nameof(Suma));
                        },
                        (object o) => czyLancuchPoprawny((string) o));
                return dodajKwote;
            }
        }

        private bool czyLancuchPoprawny(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            decimal kwota;
            if (!decimal.TryParse(s, out kwota)) return false;
            else return model.CzyKwotaJestPoprawna(kwota);
        }
    }
}
