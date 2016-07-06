using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aurm.core.utilities;

namespace aurm.core.tasks
{
    public class TimeCondition : ICondition
    {
        public TimeCondition(HashSet<DayOfWeek> activeDays, int hourOfDay, int minuteOfDay)
        {
            activeDays.ThrowIfNull(nameof(activeDays));

            if(hourOfDay < 0 || hourOfDay >= 24)
            {
                throw new ArgumentException($"{nameof(hourOfDay)} must be between 0 and 24");
            }

            if(minuteOfDay < 0 || minuteOfDay >=60)
            {
                throw new ArgumentException($"{nameof(minuteOfDay)} must be between 0 and 60");
            }

            ActiveDays = activeDays;
            HourOfDay = hourOfDay;
            MinuteOfDay = minuteOfDay;
        }

        public HashSet<DayOfWeek> ActiveDays { get; private set; }
        public int HourOfDay { get; private set; }
        public int MinuteOfDay { get; private set; }

        public bool IsMet
        {
            get
            {
                var dtNow = DateTime.Now;
                if (!this.ActiveDays.Contains(dtNow.DayOfWeek))
                {
                    //Uh uh uh... Not today!
                    return false;
                }

                if (dtNow.Hour < this.HourOfDay && dtNow.Minute < this.MinuteOfDay)
                {
                    //Not quite yet!
                    return false;
                }

                return true;
            }
        }
    }
}
