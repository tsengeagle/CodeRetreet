using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShiftScheduler
{
    //排班功能
    //設計一個排班功能
    //職員可以排自己的班，有兩個選擇，上班:true  休息:false
    //排班之後，系統依據累計排班天數，檢查排班是否符合以下規則
    //	1. 每1周要有2個休息
    //	2. 每2周要有4個休息
    //合法，提示使用者排班成功
    //非法，提示使用者排班失敗，並且提示違反哪一條規則

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ShiftSchedulerTests
    {
        [TestMethod]
        public void Input_1_ShouldReturnTrue()
        {
            var target = new Shift();
            target.Setup(true);
            var actual = target.CheckValid();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Input_111111_ShouldReturnTrue()
        {
            var target = new Shift();
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            var actual = target.CheckValid();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Input_1111111_ShouldReturnFalse_And_Message()
        {
            var target = new Shift();
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            var actual = target.CheckValid();
            Assert.IsFalse(actual);
            var actualMessage = target.CheckResult;
            Assert.AreEqual("每1周要有2個休息", actualMessage);
        }

        [TestMethod]
        public void Input_1111100_ShouldReturnTrue()
        {
            var target = new Shift();
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(true);
            target.Setup(false);
            target.Setup(false);
            var actual = target.CheckValid();
            Assert.IsTrue(actual);
        }
    }

    public class Shift
    {
        public Shift()
        {
            Schedule=new List<bool>();
        }

        public void Setup(bool isWork)
        {
            this.Schedule.Add(isWork);
        }

        public List<bool> Schedule { get; private set; }

        public bool CheckValid()
        {
            if (Schedule.Count>=7)
            {
                if (Schedule.Where(w=>w==false).Count()<2)
                {
                    CheckResult = "每1周要有2個休息";
                    return false;
                }
            }
            return true;
        }

        public string CheckResult { get; set; }
    }
}
