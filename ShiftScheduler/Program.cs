using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShiftScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //1.排班週期為一個月
    //2.週期內每兩週至少休息2日
    //3.週期內至少休8日
    //班別為上班(1)及休息(0)
    //驗證結果為通過(true)或失敗(false)
    //若為失敗，有訊息顯示違反哪一條規則
    [TestClass]
    public class ScheduleValidatorTests
    {
        [TestMethod]
        public void Test_Rule1_2016_12_Schedule_20_Days_Should_Fail()
        {
            var scheduleMonth = new DateTime(2016, 12, 1);

            var schedules = @"
1111111
1111111
111111";
            var target = new ScheduleValidator(schedules);

            var actualValid = target.CheckSchedule(scheduleMonth);
            Assert.IsFalse(actualValid);

            var actualMessage = target.CheckResult;
            Assert.AreEqual("排班週期為一個月", actualMessage);
        }
    }

    public class ScheduleValidator
    {
        private string _schedules;

        public ScheduleValidator(string schedules)
        {
            _schedules = schedules;
        }

        public string CheckResult { get; set; }

        public bool CheckSchedule(DateTime scheduleMonth)
        {
            var nextMonth=scheduleMonth.AddMonths(1);
            var scheduleMonthEndDay=nextMonth.AddDays(-1);
            var scheduleDays = (scheduleMonthEndDay - scheduleMonth).Days + 1;
            if (scheduleDays>_schedules.Length)
            {
                CheckResult = "排班週期為一個月";
                return false;
            }
            return true;
        }
    }
}
