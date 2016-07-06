using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurm.core.tasks
{
    public delegate void TaskUpdatedEvent(TaskUpdatedEventArgs e);

    public interface ITaskMonitor
    {
        void StartMonitoring();
        event TaskUpdatedEvent TaskUpdated;
    }
}
