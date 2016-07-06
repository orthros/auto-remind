using System;
using aurm.core.utilities;

namespace aurm.core.tasks
{
    public class TaskUpdatedEventArgs : EventArgs
    {
        public AurmTask RaisedTask { get; private set; }

        public TaskUpdatedEventArgs(AurmTask task) 
            : base()
        {
            task.ThrowIfNull(nameof(task));

            RaisedTask = task;
        }
    }
}