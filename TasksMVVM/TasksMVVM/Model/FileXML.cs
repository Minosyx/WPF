using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TasksMVVM.Model
{
    public static class FileXML
    {
        private static IFormatProvider formatProvider = CultureInfo.InvariantCulture;
        public static void Save(this Tasks tasks, string filePath)
        {
            try
            {
                XDocument xml = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Data zapisania: " + DateTime.Now.ToString(formatProvider)),
                    new XElement("Zadania",
                        from STask task in tasks
                        select new XElement("Zadanie",
                            new XElement("Opis", task.Desc),
                            new XElement("DataUtworzenia", task.Created.ToString(formatProvider)),
                            new XElement("PlanowanyTerminRealizacji", task.ETA.ToString(formatProvider)),
                            new XElement("Priorytet", ((byte)(task.Priority)).ToString()),
                            new XElement("CzyZrealizowane", task.Finished.ToString(formatProvider)))));
                xml.Save(filePath);
            }
            catch (Exception e)
            {
                throw new Exception("Błąd przy zapisie danych do pliku XML", e);
            }
        }

        public static Tasks Load(string filePath)
        {
            try
            {
                XDocument xml = XDocument.Load(filePath);
                IEnumerable<STask> data =
                    from task in xml.Root.Descendants("Zadanie")
                    select new STask(
                        task.Element("Opis").Value,
                        DateTime.Parse(task.Element("DataUtworzenia").Value, formatProvider),
                        DateTime.Parse(task.Element("PlanowanyTerminRealizacji").Value, formatProvider),
                        (Priority) byte.Parse(task.Element("Priorytet").Value, formatProvider),
                        bool.Parse(task.Element("CzyZrealizowane").Value));
                Tasks tasks = new Tasks();
                foreach (STask task in data) tasks.AddTask(task);
                return tasks;
            }
            catch (Exception e)
            {
                throw new Exception("Błąd przy odczycie danych z pliku XML", e);
            }
        }
    }
}
