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

    //1.排班以月為單位
    //2.每2周要有2天休假
    //3.每4周休假+休息至少8天
    //班別分為上班、休息、休假
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

        [Ignore]
        [TestCategory("周休二日")]
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

        [TestMethod]
        public void ValidatorTest_ShiftDays31_ButCrossMonth_ShouldFail()
        {
            var shifts = MakeShifts5DaysOn2DaysOff31DaysButCrossMonth();

            var target = new ScheduleValidator(shifts);
            var actualStatus = target.CheckIfValid();

            Assert.IsFalse(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_5daysOn_2daysOff_ButNotOrderByDate_ShouldSuccess()
        {
            var shifts = MakeShifts5DaysOn2DaysOffButNotOrderByDate();

            var target = new ScheduleValidator(shifts);
            var actualStatus = target.CheckIfValid();

            Assert.IsTrue(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_5daysOn_1dayOff_1dayBreak_ShouldSuccess()
        {
            var shifts = MakeShifts5DaysOn1DayOff1DayBreak();
            var target = new ScheduleValidator(shifts);

            var actualStatus = target.CheckIfValid();

            Assert.IsTrue(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_Total_4DaysOff_2DaysBreak_ShouldFail()
        {
            var shifts = MakeShiftsTotal4DaysOff2DaysBreak();
            var target = new ScheduleValidator(shifts);

            var actualStatus = target.CheckIfValid();

            Assert.IsFalse(actualStatus);
        }

        [TestMethod]
        public void ValidatorTest_Total_4DaysOff_4DaysBreak_ShouldSuccess()
        {
            var shifts = MakeShiftsTotal4DaysOff4DaysBreak();
            var target = new ScheduleValidator(shifts);

            var actualStatus = target.CheckIfValid();

            Assert.IsTrue(actualStatus);
        }

        private List<Shift> MakeShifts5DaysOn2DaysOffButNotOrderByDate()
        {
            return new List<Shift>()
            {
                new Shift() {Date=new DateTime(2017,1,31),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,2),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,1),Type="上班" },
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
            };
        }
        private List<Shift> MakeShifts5DaysOn2DaysOff31DaysButCrossMonth()
        {
            return new List<Shift>()
            {
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
        private List<Shift> MakeShifts5DaysOn1DayOff1DayBreak()
        {
            return new List<Shift>()
            {
                new Shift() {Date=new DateTime(2017,1,1),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,2),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,3),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,4),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,5),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,6),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,7),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,8),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,9),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,10),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,11),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,12),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,13),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,14),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,15),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,16),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,17),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,18),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,19),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,20),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,21),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,22),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,23),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,24),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,25),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,26),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,27),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,28),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,29),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,30),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,31),Type="上班" },
            };
        }
        private List<Shift> MakeShiftsTotal4DaysOff2DaysBreak()
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
                new Shift() {Date=new DateTime(2017,1,20),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,21),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,22),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,23),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,24),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,25),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,26),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,27),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,28),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,29),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,30),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,31),Type="上班" },
            };
        }
        private List<Shift> MakeShiftsTotal4DaysOff4DaysBreak()
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
                new Shift() {Date=new DateTime(2017,1,19),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,20),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,21),Type="休假" },
                new Shift() {Date=new DateTime(2017,1,22),Type="休息" },
                new Shift() {Date=new DateTime(2017,1,23),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,24),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,25),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,26),Type="上班" },
                new Shift() {Date=new DateTime(2017,1,27),Type="休息" },
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
            _shifts = shifts.OrderBy(o => o.Date).ToList();
        }

        public bool CheckIfValid()
        {
            var checkResult = true;

            var firstShiftDate = _shifts.First().Date;

            var shouldShiftDays = DateTime.DaysInMonth(firstShiftDate.Year,firstShiftDate.Month);
            if (_shifts.Count() != shouldShiftDays)
            {
                checkResult = false;
            }

            if (_shifts.Where(w => w.Date.Month != firstShiftDate.Month).Count() > 0)
            {
                checkResult = false;
            }

            foreach (var shift in _shifts.OrderByDescending(o => o.Date))
            {
                var currentDate = shift.Date;

                var weekShifts = _shifts.Where(w => w.Date <= shift.Date).OrderByDescending(o => o.Date).Take(14);
                if (weekShifts.Count() == 14)
                {
                    if (weekShifts.Where(w => w.Type == "休假").Count() < 2)
                    {
                        checkResult = false;
                    }
                }

                var monthShits = _shifts.Where(w => w.Date <= shift.Date).OrderByDescending(o => o.Date).Take(28);
                if (monthShits.Count() == 28)
                {
                    if (monthShits.Where(w => w.Type == "休假" || w.Type == "休息").Count() < 8)
                    {
                        checkResult = false;
                    }
                }
            }

            return checkResult;
        }
    }
}
