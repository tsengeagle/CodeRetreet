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

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ShiftSchedulerTests
    {
        //排班功能
        //設計一個排班功能
        //職員可以排自己的班，有兩個選擇，上班:true  休息:false
        //排班之後，系統依據累計排班天數，檢查排班是否符合以下規則
        //	1. 每1周要有2個休息
        //	2. 每2周要有4個休息
        //合法，提示使用者排班成功
        //非法，提示使用者排班失敗，並且提示違反哪一條規則

        //排班資訊:日期、班別

        [TestMethod]
        public void Shift_1dayOn_ShouldSuccess()
        {
            var target = new Scheduler();
            var shift = new Shift() { Date = new DateTime(2017, 1, 1), Class = true };


            var actualValid = target.SetSchedule(shift);

            Assert.IsTrue(actualValid);
        }

        [TestMethod]
        public void Shift_6dayOn_1dayOff_ShouldFail()
        {
            var target = new Scheduler();
            var shift = new Shift() { Date = new DateTime(2016, 12, 31), Class = true };
            var shift1 = new Shift() { Date = new DateTime(2017, 1, 1), Class = true };
            var shift2 = new Shift() { Date = new DateTime(2017, 1, 2), Class = true };
            var shift3 = new Shift() { Date = new DateTime(2017, 1, 3), Class = true };
            var shift4 = new Shift() { Date = new DateTime(2017, 1, 4), Class = true };
            var shift5 = new Shift() { Date = new DateTime(2017, 1, 5), Class = true };
            var shift6 = new Shift() { Date = new DateTime(2017, 1, 6), Class = true };
            var shift7 = new Shift() { Date = new DateTime(2017, 1, 7), Class = false };

            target.SetSchedule(shift);

            target.SetSchedule(shift1);
            target.SetSchedule(shift2);
            target.SetSchedule(shift3);
            target.SetSchedule(shift4);
            target.SetSchedule(shift5);
            target.SetSchedule(shift6);
            var actualValid7 = target.SetSchedule(shift7);
            Assert.IsFalse(actualValid7);
        }

        [TestMethod]
        public void Shift_5dayOn_2dayOff_ShouldSuccess()
        {
            var target = new Scheduler();
            var shift1 = new Shift() { Date = new DateTime(2017, 1, 1), Class = true };
            var shift2 = new Shift() { Date = new DateTime(2017, 1, 2), Class = true };
            var shift3 = new Shift() { Date = new DateTime(2017, 1, 3), Class = true };
            var shift4 = new Shift() { Date = new DateTime(2017, 1, 4), Class = true };
            var shift5 = new Shift() { Date = new DateTime(2017, 1, 5), Class = true };
            var shift6 = new Shift() { Date = new DateTime(2017, 1, 6), Class = false };
            var shift7 = new Shift() { Date = new DateTime(2017, 1, 7), Class = false };

            target.SetSchedule(shift1);
            target.SetSchedule(shift2);
            target.SetSchedule(shift3);
            target.SetSchedule(shift4);
            target.SetSchedule(shift5);
            var actualValid6 = target.SetSchedule(shift6);
            Assert.IsTrue(actualValid6);
            var actualValid7 = target.SetSchedule(shift7);
            Assert.IsTrue(actualValid7);
        }

        [TestMethod]
        public void Shift_3dayOn_2dayOff_2dayOn_ShouldSuccess()
        {
            var target = new Scheduler();
            var shift1 = new Shift() { Date = new DateTime(2017, 1, 1), Class = true };
            var shift2 = new Shift() { Date = new DateTime(2017, 1, 2), Class = true };
            var shift3 = new Shift() { Date = new DateTime(2017, 1, 3), Class = true };
            var shift4 = new Shift() { Date = new DateTime(2017, 1, 4), Class = false };
            var shift5 = new Shift() { Date = new DateTime(2017, 1, 5), Class = false };
            var shift6 = new Shift() { Date = new DateTime(2017, 1, 6), Class = true };
            var shift7 = new Shift() { Date = new DateTime(2017, 1, 7), Class = true };

            target.SetSchedule(shift1);
            target.SetSchedule(shift2);
            target.SetSchedule(shift3);
            target.SetSchedule(shift4);
            target.SetSchedule(shift5);
            var actualValid6 = target.SetSchedule(shift6);
            Assert.IsTrue(actualValid6);
            var actualValid7 = target.SetSchedule(shift7);
            Assert.IsTrue(actualValid7);
        }

        [TestMethod]
        public void Shift_5dayOn_2dayOff_Then_6dayOn_1dayOff_ShouldFail()
        {
            var shifts = new List<Shift>
            {
                new Shift() {Date = new DateTime(2017, 1, 1), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 2), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 3), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 4), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 5), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 6), Class = false},
                new Shift() {Date = new DateTime(2017, 1, 7), Class = false},
                new Shift() {Date = new DateTime(2017, 1, 8), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 9), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 10), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 11), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 12), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 13), Class = true}
            };
            var target = new Scheduler(shifts);
            var shift = new Shift() { Date = new DateTime(2017, 1, 14), Class = false };

            var actualValid = target.SetSchedule(shift);

            Assert.IsFalse(actualValid);
        }

        [TestMethod]
        public void Shift_3dayOn_2dayOff_2dayOn_then_5dayOn_ShouldFail()
        {
            var shifts = new List<Shift>
            {
                new Shift() {Date = new DateTime(2017, 1, 1), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 2), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 3), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 4), Class = false},
                new Shift() {Date = new DateTime(2017, 1, 5), Class = false},
                new Shift() {Date = new DateTime(2017, 1, 6), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 7), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 8), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 9), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 10), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 11), Class = true}
            };
            var target = new Scheduler(shifts);
            var shift = new Shift() { Date = new DateTime(2017, 1, 12), Class = true };

            var actualValid = target.SetSchedule(shift);

            Assert.IsFalse(actualValid);
        }

        [TestMethod]
        public void Shift_3dayOn_2dayOff_2dayOn_Then_5dayOn_2dayOff_ShouldFail_ShouldReturnMessage()
        {
            var shifts = new List<Shift>
            {
                new Shift() {Date = new DateTime(2017, 1, 1), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 2), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 3), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 4), Class = false},
                new Shift() {Date = new DateTime(2017, 1, 5), Class = false},
                new Shift() {Date = new DateTime(2017, 1, 6), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 7), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 8), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 9), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 10), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 11), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 12), Class = true},
                new Shift() {Date = new DateTime(2017, 1, 13), Class = false},
                new Shift() {Date = new DateTime(2017, 1, 14), Class = false},
            };
            var target = new Scheduler(shifts);

            var actualValid = target.IsShiftsValid;
            var actualMessage = target.Message;

            Assert.IsFalse(actualValid);
            Assert.AreEqual("每1周要有2個休息", actualMessage);
        }
        
    }

    public class Shift
    {
        public DateTime Date { get; set; }
        public bool Class { get; set; }
    }

    public class Scheduler
    {
        private List<Shift> _shifts;

        public Scheduler()
        {
            this._shifts = new List<Shift>();
        }

        public Scheduler(List<Shift> shifts)
        {
            IsShiftsValid = true;
            _shifts = shifts;
        }

        public string Message { get; set; }
        public bool IsShiftsValid { get; set; }

        public bool SetSchedule(Shift shift)
        {
            _shifts.Add(shift);

            return CheckShiftsValid();
        }

        public bool CheckShiftsValid()
        {
            if (_shifts.OrderByDescending(o => o.Date).Take(7).Where(w => w.Class == true).Count() > 5)
            {
                Message = "每1周要有2個休息";
                IsShiftsValid = false;
                return false;
            }
            return true;
        }
    }
}
