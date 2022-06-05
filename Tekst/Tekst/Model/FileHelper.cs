using System.IO;

namespace Tekst.Model
{
    public static class FileHelper
    {
        private const string FileName = "settings.txt";
        public static void Save(this TModel model)
        {
            string s = model.Tekst;
            File.WriteAllText(FileName, s);
        }

        public static TModel Read()
        {
            try
            {
                string s = File.ReadAllText(FileName);
                return new TModel() { Tekst = s };
            }
            catch
            {
                return new TModel();
            }
        }
    }
}
