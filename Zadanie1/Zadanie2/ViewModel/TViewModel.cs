using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zadanie2.ViewModel
{
    using Model;
    public class TViewModel : INotifyPropertyChanged
    {
        private TModel model = new TModel();
        private ICommand czyść;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Tekst
        {
            get => model.Tekst;
            set
            {
                model.Tekst = value;
                onPropertyChanged(nameof(Tekst));
            }
        }

        public ICommand Czyść
        {
            get
            {
                if (czyść == null)
                    czyść = new RelayCommand(
                        o =>
                        {
                            model.Clear();
                            onPropertyChanged(nameof(Tekst));
                        },
                        o => !string.IsNullOrEmpty(model.Tekst)
                    );
                return czyść;
            }
        }
    }
}
