using aurm.core.tasks;
using aurm.core.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace aurm.core.tests.notifications
{
    public class NotificationTests
    {
        [Fact]
        public void TestTimeConditionNullConstructor()
        {
            HashSet<DayOfWeek> daysOfWeek = null;
            Assert.Throws<ArgumentNullException>("activeDays", 
                                                 () => 
                                                 {
                                                     TimeCondition tc = new TimeCondition(daysOfWeek, 0, 0);
                                                 });            
        }

        [Fact]
        public void TestTimeConditionNegativeMinuteConstructor()
        {
            //Every day
            HashSet<DayOfWeek> daysOfWeek =  new HashSet<DayOfWeek>(EnumUtil.GetValues<DayOfWeek>());
            int hours = 1;
            int minutes = -1;
            Assert.Throws<ArgumentException>(() => 
            {
                TimeCondition tc = new TimeCondition(daysOfWeek, hours, minutes);
            });
        }

        [Fact]
        public void TestTimeConditionOver60MinuteConstructor()
        {
            //Every day
            HashSet<DayOfWeek> daysOfWeek = new HashSet<DayOfWeek>(EnumUtil.GetValues<DayOfWeek>());
            int hours = 1;
            int minutes = 61;
            Assert.Throws<ArgumentException>(() =>
            {
                TimeCondition tc = new TimeCondition(daysOfWeek, hours, minutes);
            });
        }

        [Fact]
        public void TestTimeConditionNegativeHourConstructor()
        {
            //Every day
            HashSet<DayOfWeek> daysOfWeek = new HashSet<DayOfWeek>(EnumUtil.GetValues<DayOfWeek>());
            int hours = -1;
            int minutes = 45;
            Assert.Throws<ArgumentException>(() =>
            {
                TimeCondition tc = new TimeCondition(daysOfWeek, hours, minutes);
            });
        }

        [Fact]
        public void TestTimeConditionOver24HourConstructor()
        {
            //Every day
            HashSet<DayOfWeek> daysOfWeek = new HashSet<DayOfWeek>(EnumUtil.GetValues<DayOfWeek>());
            int hours = 25;
            int minutes = 45;
            Assert.Throws<ArgumentException>(() =>
            {
                TimeCondition tc = new TimeCondition(daysOfWeek, hours, minutes);
            });
        }
    }
}
