using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksMVVM.Model
{
    public class Tasks : IEnumerable<STask>
    {
        private List<STask> tasks = new List<STask>();

        public void AddTask(STask task)
        {
            tasks.Add(task);
        }

        public bool DeleteTask(STask task)
        {
            return tasks.Remove(task);
        }

        public int Count => tasks.Count;

        public STask this[int index] => tasks[index];

        public IEnumerator<STask> GetEnumerator()
        {
            return tasks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
