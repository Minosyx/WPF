using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMFirst.ModelWidoku
{
    using Model;
    public class ModelWidokuMVVM : INotifyPropertyChanged
    {
        private ModelMVVM model = FileHelper.Read();
        public event PropertyChangedEventHandler? PropertyChanged;
        private ICommand resetuj;

        public double Wartość
        {
            get => model.Wartość;
            set
            {
                model.Wartość = value;
                onPropertyChanged(nameof(Wartość));
                model.Save();
            }
        }

        protected void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Resetuj
        {
            get
            {
                if (resetuj == null) return new RelayCommand(
                    (object o) =>
                    {
                        model.Resetuj();
                        onPropertyChanged(nameof(Wartość));
                    },
                    (object o) => model.Wartość > 0);
                return resetuj;
            }
        }
    }
}
