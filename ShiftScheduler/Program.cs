using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
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

    //排班驗證器
    //輸入排班
    //輸出驗證結果

    //排班以月為單位
    //班別分為上班、休息、休假

    //月排班:排班月份+List<排班>
    //排班:日期+班別

    //Part1
    //1.每7天要有1天休息+1天休假

    //Part2
    //1.每2周要有2天休假
    //2.每4周休假+休息至少8天(4天休假+4天休息)

    //驗證須滿足Part1或Part2
    //結果為通過(true)或失敗(false)
    //若結果為失敗，需提示在哪一個時間區間內違反哪一項原則

    [TestClass]
    public class ShiftValidatorTests
    {
        [TestMethod]
        public void ValidatorTest_Shift201701_EveryWeek_Off1Day_Break1Day_ShouldSuccess()
        {
            var monthShift = new MonthShift();
            monthShift.Shifts = Get_Shift201701_EveryWeek_Off1Day_Break1Day();

            var target = new ShiftValidator(monthShift);

            var actualStatus = target.CheckEveryWeekHasOffAndBreak();
            Assert.IsTrue(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_Shift201701_FirstWeek_AlldaysOn_ShouldFail_ShouldGetErrorMessage()
        {
            var monthShift = new MonthShift();
            monthShift.Shifts = Get_Shift201701_FirstWeek_AlldaysOn();

            var target = new ShiftValidator(monthShift);

            var actualStatus = target.CheckEveryWeekHasOffAndBreak();
            Assert.IsFalse(actualStatus);

            var actualMessage = target.GetErrorMessage();
            string expectedMessage = "排班日期:2017/01/11 違反每周必須有1天休息1天休假之規則";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ValidatorTest_Shift201701_2WeekHas2DaysOff_4WeekHas8Days_ShouldSeccess()
        {
            var monthShift = new MonthShift();
            monthShift.Shifts = Get_Shift201701_2WeekHas2DaysOff_4WeekHas8Days();

            var target = new ShiftValidator(monthShift);

            var actualStatus = target.Check1Off1Break();
            Assert.IsTrue(actualStatus);

        }

        private List<DayShift> Get_Shift201701_2WeekHas2DaysOff_4WeekHas8Days()
        {
            var result = new List<DayShift>()
            {
                new DayShift() {Date=new DateTime(2017,1,1),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,2),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,3),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,4),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,5),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,6),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,7),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,8),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,9),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,10),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,11),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,12),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,13),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,14),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,15),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,16),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,17),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,18),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,19),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,20),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,21),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,22),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,23),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,24),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,25),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,26),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,27),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,28),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,29),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,30),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,31),Shift="上班" }
            };

            return result;
        }

        private List<DayShift> Get_Shift201701_FirstWeek_AlldaysOn()
        {
            var result = new List<DayShift>()
            {
                new DayShift() {Date=new DateTime(2017,1,1),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,2),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,3),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,4),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,5),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,6),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,7),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,8),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,9),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,10),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,11),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,12),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,13),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,14),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,15),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,16),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,17),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,18),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,19),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,20),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,21),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,22),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,23),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,24),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,25),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,26),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,27),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,28),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,29),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,30),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,31),Shift="上班" }
            };

            return result;
        }

        private List<DayShift> Get_Shift201701_EveryWeek_Off1Day_Break1Day()
        {
            var result = new List<DayShift>()
            {
                new DayShift() {Date=new DateTime(2017,1,1),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,2),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,3),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,4),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,5),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,6),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,7),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,8),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,9),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,10),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,11),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,12),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,13),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,14),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,15),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,16),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,17),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,18),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,19),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,20),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,21),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,22),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,23),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,24),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,25),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,26),Shift="休息" },
                new DayShift() {Date=new DateTime(2017,1,27),Shift="休假" },
                new DayShift() {Date=new DateTime(2017,1,28),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,29),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,30),Shift="上班" },
                new DayShift() {Date=new DateTime(2017,1,31),Shift="上班" }
            };

            return result;
        }
    }

    public class ShiftValidator
    {
        private MonthShift _monthShift;
        private string _errorMessage;

        public ShiftValidator(MonthShift monthShift)
        {
            _monthShift = monthShift;
        }

        public bool CheckEveryWeekHasOffAndBreak()
        {
            var shift = _monthShift.GetShiftsForValid();// _monthShift.Shifts.OrderByDescending(o => o.Date).ToList();

            foreach (var currentShift in shift)
            {
                var weekShifts = shift.Where(w => w.Date <= currentShift.Date).Take(7);
                if (weekShifts.Count() == 7)
                {
                    if (weekShifts.Where(w => w.Shift == "休假").Count() < 1 & weekShifts.Where(w => w.Shift == "休息").Count() < 1)
                    {
                        _errorMessage = string.Format("排班日期:{0} 違反每周必須有1天休息1天休假之規則", currentShift.Date.ToString("yyyy/MM/dd"));
                        return false;
                    }
                }
            }
            return true;
        }

        internal string GetErrorMessage()
        {
            return _errorMessage;
        }

        public bool Check1Off1Break()
        {
            var result = true;
            var shift = _monthShift.GetShiftsForValid();
            foreach (var currentShift in shift)
            {
                var twoWeekShifts = shift.Where(w => w.Date <= currentShift.Date).Take(14);
                if (twoWeekShifts.Count()==14)
                {
                    if (twoWeekShifts.Where(w=>w.Shift=="休假").Count()<2)
                    {
                        result = false;
                    }
                }

                var fourWeekShifts = shift.Where(w => w.Date <= currentShift.Date).Take(28);
                if (fourWeekShifts.Count()==28)
                {
                    if (fourWeekShifts.Where(w=>w.Shift=="休假").Count()<4 & fourWeekShifts.Where(w => w.Shift == "休息").Count() < 4)
                    {
                        result = false;
                    }
                }
            }
            return result;;
        }
    }

    public class DayShift
    {
        public string Shift { get; set; }
        public DateTime Date { get; set; }
    }

    public class MonthShift
    {
        public List<DayShift> Shifts { get; set; }

        public List<DayShift> GetShiftsForValid()
        {
            return this.Shifts.OrderByDescending(o => o.Date).ToList();
        }
    }
}
