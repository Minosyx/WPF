using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class ObservedObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void onPropertyChanged(params string[] propertiesNames)
    {
        if (PropertyChanged == null) return;
        foreach (string name in propertiesNames)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}

