using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            AProperty = 0;
            BProperty = 0;
            CProperty = 0;
        }
        private double _AProperty;
        private double _BProperty;
        private double _CProperty;
        public double AProperty
        {
            get => _AProperty;
            set
            {
                _AProperty = value;
                NotifyPropertyChanged();
            }
        }

        public double BProperty
        {
            get => _BProperty;
            set
            {
                _BProperty = value;
                NotifyPropertyChanged();
            }
        }

        public double CProperty
        {
            get => _CProperty;
            set
            {
                _CProperty = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
