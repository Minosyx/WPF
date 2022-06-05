using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TasksMVVM.Model;

namespace TasksMVVM.ViewModel
{
    using static Model.FileXML;
    public class Tasks
    {
        private Model.Tasks model;
        public ObservableCollection<STask> TaskList { get; } = new ObservableCollection<STask>();

        private void copyFromModel()
        {
            TaskList.CollectionChanged -= modelSync;
            TaskList.Clear();
            foreach (Model.STask task in model)
                TaskList.Add(new STask(task));
            TaskList.CollectionChanged += modelSync;
        }

        private string filePath = "zadania.xml";

        public Tasks()
        {
            if (File.Exists(filePath)) model = Load(filePath);
            else model = new Model.Tasks();

            //Testy
            //model.AddTask(new Model.STask("Pierwsze", DateTime.Now, DateTime.Now.AddDays(3), Model.Priority.Higher));
            //model.AddTask(new Model.STask("Drugie", DateTime.Now, DateTime.Now.AddDays(2), Model.Priority.Lower));
            //model.AddTask(new Model.STask("Trzecie", DateTime.Now, DateTime.Now.AddDays(5), Model.Priority.Critical));

            copyFromModel();
        }

        private void modelSync(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    STask newTask = (STask) e.NewItems[0];
                    if (newTask != null) model.AddTask(newTask.GetModel());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    STask delTask = (STask) e.OldItems[0];
                    if (delTask != null) model.DeleteTask(delTask.GetModel());
                    break;
            }
        }

        public ICommand Save
        {
            get
            {
                return new RelayCommand(
                    o => model.Save(filePath)
                    );
            }
        }

        private ICommand deleteTask;

        public ICommand DeleteTask
        {
            get
            {
                if (deleteTask == null)
                    deleteTask = new RelayCommand(
                        o =>
                        {
                            int index = (int) o;
                            STask task = TaskList[index];
                            TaskList.Remove(task);
                        },
                        o =>
                        {
                            if (o == null) return false;
                            int index = (int) o;
                            return index >= 0;
                        });
                return deleteTask;
            }
        }

        private ICommand addTask;

        public ICommand AddTask
        {
            get
            {
                if (addTask == null)
                    addTask = new RelayCommand(
                        o =>
                        {
                            if (o is STask task) TaskList.Add(task);
                        },
                        o => (o as STask) != null);
                return addTask;
            }
        }
    }
}
