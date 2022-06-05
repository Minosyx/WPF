using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksMVVM.Model
{
    public enum Priority : byte { Lower, Higher, Critical }
    public class STask
    {
        public string Desc { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime ETA { get; private set; }
        public Priority Priority { get; private set; }
        public bool Finished { get; set; }

        public STask(string desc, DateTime created, DateTime eta, Priority priority, bool finished = false)
        {
            Desc = desc;
            Created = created;
            ETA = eta;
            Priority = priority;
            Finished = finished;
        }

        public override string ToString() => Desc + ", priotytet: " + Priority + ", data utworzenia: "
                                             + Created + ", planowany termin realizacji: " + ETA +
                                             ", czy zrealizowane: " + (Finished ? "tak" : "nie");
    }
}
