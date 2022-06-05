using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirst.Model
{
    public static class FileHelper
    {
        private const string FileName = "settings.txt";
        public static void Save(this ModelMVVM model)
        {
            string s = model.Wartość.ToString();
            File.WriteAllText(FileName, s);
        }

        public static ModelMVVM Read()
        {
            try
            {
                string s = File.ReadAllText(FileName);
                double wartość = double.Parse(s);
                return new ModelMVVM() {Wartość = wartość};
            }
            catch
            {
                return new ModelMVVM();
            }
        }
    }
}
