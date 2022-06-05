using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorsMVVM.Model
{
    public static class Settings
    {
        public static MColor Read()
        {
            Properties.Settings settings = Properties.Settings.Default;
            return new MColor(settings.R, settings.G, settings.B);
        }

        public static void Save(this MColor model)
        {
            Properties.Settings settings = Properties.Settings.Default;
            settings.R = model.R;
            settings.G = model.G;
            settings.B = model.B;
            settings.Save();
        }
    }
}
