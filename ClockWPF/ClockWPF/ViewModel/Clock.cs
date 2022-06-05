using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ClockWPF.ViewModel
{
    public class Clock : ObservedObject
    {
        private readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());

        public DateTime CurrentTime => DateTime.Now;

        private DateTime previousTime = DateTime.Now;

        private const int refreshRate = 250;

        public Clock()
        {
            DispatcherTimer refreshTimer = new();
            refreshTimer.Tick += (sender, e) =>
            {
                if (CurrentTime.Second != previousTime.Second)
                {
                    previousTime = CurrentTime;
                    onPropertyChanged(nameof(CurrentTime));
                }
            };
            refreshTimer.Interval = TimeSpan.FromMilliseconds(refreshRate);
            if (!isInDesignMode) refreshTimer.Start();
        }
    }
}
