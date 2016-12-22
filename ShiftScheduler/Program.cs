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
        {;
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

    }
}
