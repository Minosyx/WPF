using System.ComponentModel;
using System.Windows.Input;

namespace Tekst.ModelView
{
    using Model;
    public class TModelView : INotifyPropertyChanged
    {
        private TModel model = FileHelper.Read();
        private ICommand clear;

        public string Tekst
        {
            get => model.Tekst;
            set
            {
                model.Tekst = value;
                onPropertyChanged(nameof(Tekst));
                model.Save();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void onPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Clear
        {
            get
            {
                if (clear == null)
                    clear = new RelayCommand(
                        (object o) =>
                        {
                            model.Clear();
                            onPropertyChanged(nameof(Tekst));
                        },
                        (object o) => model.Tekst.Length > 0);
                return clear;
            }
        }
    }
}
