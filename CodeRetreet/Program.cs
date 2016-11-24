using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRetreet
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        internal bool CheckResult()
        {
            var condition = false;
            if (condition)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// TDD的重要精神
    /// 再設法通過第二個測試的同時，必須確保前面的測試維持綠燈
    /// 一次只能出現一個紅燈，沒有紅燈之前不改prod code
    /// </summary>
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void MyFirstTest()
        {
            var target = new Program();

            Assert.IsTrue(target.CheckResult());
        }

        [TestMethod]
        public void SecondTest_IsFalse()
        {
            var target = new Program();
            Assert.IsFalse(target.CheckResult());
        }
    }
}
