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
            ;
        }
    }

    //1.排班週期為一個月
    //2.週期內每1周需有2天休假
    //班別為上班及休息
    //驗證結果為通過(true)或失敗(false)
    //若為失敗，有訊息顯示違反哪一條規則
    [TestClass]
    public class ScheduleValidatorTests
    {
        [TestMethod]
        public void ValidatorTest_0daysOff_ShouldFail()
        {
            var shifts = MakeShiftsAllOn();

            var target = new ScheduleValidator(shifts);
            var actualStatus = target.CheckIfValid();

            Assert.IsFalse(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_5daysOn_2daysOff_ShouldSuccess()
        {
            var shifts = MakeShifts5DaysOn2DaysOff();

            var target = new ScheduleValidator(shifts);
            var actualStatus = target.CheckIfValid();

            Assert.IsTrue(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_6daysOn_1daysOff_ShouldFail()
        {
            var shifts = MakeShifts6DaysOn1DaysOff();

            var target = new ScheduleValidator(shifts);
            var actualStatus = target.CheckIfValid();

            Assert.IsFalse(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_Shift20Days_ShouldFail()
        {
            var shifts = MakeShifts5DaysOn2DaysOffBut20Days();

            var target = new ScheduleValidator(shifts);
            var actualStatus = target.CheckIfValid();

            Assert.IsFalse(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_ShiftCrossMonth_ShouldFail()
        {
            var shifts = MakeShifts5DaysOn2DaysOffButCrossMonth();

            var target = new ScheduleValidator(shifts);
            var actualStatus = target.CheckIfValid();

            Assert.IsFalse(actualStatus);
        }

        private List<Shift> MakeShifts5DaysOn2DaysOffButCrossMonth()
        {
            return new List<Shift>()
            {
                new Shift() {Date=new DateTime(2017,1,1),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,2),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,3),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,4),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,5),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,6),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,7),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,8),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,9),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,10),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,11),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,12),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,13),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,14),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,15),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,16),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,17),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,18),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,19),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,20),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,21),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,22),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,23),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,24),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,25),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,26),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,27),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,28),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,29),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,30),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,31),Type="上班" },
                new Shift() {Date=new DateTime(2017,2,1),Type="上班" },
            };
        }
        private List<Shift> MakeShifts5DaysOn2DaysOffBut20Days()
        {
            return new List<Shift>()
            {
                new Shift() {Date=new DateTime(2017,1,1),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,2),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,3),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,4),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,5),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,6),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,7),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,8),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,9),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,10),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,11),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,12),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,13),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,14),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,15),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,16),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,17),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,18),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,19),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,20),Type="休假" },
            };
        }
        private List<Shift> MakeShifts6DaysOn1DaysOff()
        {
            return new List<Shift>()
            {
                new Shift() {Date=new DateTime(2017,1,1),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,2),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,3),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,4),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,5),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,6),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,7),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,8),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,9),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,10),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,11),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,12),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,13),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,14),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,15),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,16),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,17),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,18),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,19),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,20),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,21),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,22),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,23),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,24),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,25),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,26),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,27),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,28),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,29),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,30),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,31),Type="上班" },
            };
        }
        private List<Shift> MakeShiftsAllOn()
        {
            return new List<Shift>()
            {
                new Shift() {Date=new DateTime(2017,1,1),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,2),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,3),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,4),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,5),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,6),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,7),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,8),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,9),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,10),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,11),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,12),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,13),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,14),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,15),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,16),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,17),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,18),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,19),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,20),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,21),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,22),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,23),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,24),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,25),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,26),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,27),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,28),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,29),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,30),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,31),Type="上班" },
            };
        }
        private List<Shift> MakeShifts5DaysOn2DaysOff()
        {
            return new List<Shift>()
            {
                new Shift() {Date=new DateTime(2017,1,1),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,2),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,3),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,4),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,5),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,6),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,7),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,8),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,9),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,10),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,11),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,12),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,13),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,14),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,15),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,16),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,17),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,18),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,19),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,20),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,21),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,22),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,23),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,24),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,25),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,26),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,27),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,28),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,29),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,30),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,31),Type="上班" },
            };
        }
    }

    public class Shift
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class ScheduleValidator
    {
        private List<Shift> _shifts;

        public ScheduleValidator(List<Shift> shifts)
        {
            _shifts = shifts;
        }

        public bool CheckIfValid()
        {
            var checkResult = true;

            var firstShiftDate = _shifts.First().Date;
            var nextMonth=firstShiftDate.AddMonths(1);
            var shouldShiftDays = (nextMonth - firstShiftDate).Days;
            if (_shifts.Count()!=shouldShiftDays)
            {
                checkResult = false;
            }

            foreach (var shift in _shifts.OrderByDescending(o => o.Date))
            {
                var weekShifts = _shifts.Where(w => w.Date <= shift.Date).OrderByDescending(o => o.Date).Take(7);
                if (weekShifts.Count() == 7)
                {
                    if (weekShifts.Where(w => w.Type == "休假").Count() < 2)
                    {
                        checkResult = false;
                    }
                }
            }

            return checkResult;
        }
    }
}
