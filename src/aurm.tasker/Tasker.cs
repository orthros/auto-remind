﻿using aurm.core.tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using aurm.core.utilities;

namespace aurm.tasker
{
    public class Tasker :ITaskMonitor
    {
        public Tasker(List<AurmTask> tasks)
        {
            tasks.ThrowIfNull(nameof(tasks));

            Tasks = tasks;
        }

        public event TaskUpdatedEvent TaskUpdated;

        private Timer OurTimer { get; set; }

        private List<AurmTask> Tasks { get; set; }

        public void StartMonitoring()
        {
            //Timer on a One minute cycle
            //When it ticks, check all Tasks and if they are "complete" raise the TaskUpdatedEvent
            OurTimer = new Timer();
            OurTimer.Interval = 1000 * 60;
            OurTimer.Elapsed += OurTimer_Elapsed;
            OurTimer.Start();
        }

        private void OurTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Tasks.ForEach((task) =>
            {
                if (task.TimeCondition.IsMet && task.AdditionalConditions.All(x => x.IsMet))
                {
                    //Raise our event
                    OnTaskUpdated(task);
                }
            });
        }

        private void OnTaskUpdated(AurmTask task)
        {
            //Shiny new "?" syntax. Need to remind people to use VS 2015 or later
            TaskUpdated?.Invoke(new TaskUpdatedEventArgs(task));
        }
    }
}