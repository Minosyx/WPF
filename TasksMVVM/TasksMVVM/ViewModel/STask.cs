using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;

namespace TasksMVVM.ViewModel
{
    public class STask : ObservedObject
    {
        private Model.STask model;

        #region Properties

        public string Desc => model.Desc;
        public Model.Priority Priority => model.Priority;
        public DateTime Created => model.Created;
        public DateTime ETA => model.ETA;
        public bool Finished => model.Finished;
        public bool UnfinishedAfterETA => !Finished && (DateTime.Now > ETA);

        #endregion

        public STask(Model.STask model)
        {
            this.model = model;
        }

        public STask(string desc, DateTime created, DateTime eta, Model.Priority priority, bool finished)
        {
            model = new Model.STask(desc, created, eta, priority, finished);
        }

        public Model.STask GetModel() => model;

        #region Commands

        private ICommand markFinished;

        public ICommand MarkFinished
        {
            get
            {
                if (markFinished == null)
                    markFinished =
                        new RelayCommand(
                            o =>
                            {
                                model.Finished = true;
                                onPropertyChanged(nameof(Finished), nameof(UnfinishedAfterETA));
                            },
                            o => !model.Finished);
                return markFinished;
            }
        }

        private ICommand markUnfinished;

        public ICommand MarkUnfinished
        {
            get
            {
                if (markUnfinished == null)
                    markUnfinished =
                        new RelayCommand(
                            o =>
                            {
                                model.Finished = false;
                                onPropertyChanged(nameof(Finished), nameof(UnfinishedAfterETA));
                            },
                            o => model.Finished);
                return markUnfinished;
            }
        }

        #endregion

        public override string ToString() => model.ToString();
    }
}
