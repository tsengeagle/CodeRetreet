using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int Score(List<int> squares)
        {
            var result = 0;
            foreach (var square in squares)
            {
                if (square != 10)
                {
                    result += square;
                }
                else
                {
                    //bonus的分數要怎麼處理?
                }
            }
            return result;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {
        //10支瓶子
        //每局10格，每格可以丟兩次
        //每格得分為擊倒的瓶數
        //第一次丟就擊倒10瓶，叫做全倒，bonus是接下來兩次丟球的擊倒瓶數
        //兩次丟擊倒10瓶，叫做spare，bonus是下一次丟球的擊倒瓶數
        //第10格如果有全倒，可以加丟2次；如果spare，可以加丟一次
        //第10格最多丟3次

        [TestMethod]
        public void BowlingScore_Roll8_ShouldReturn_8()
        {
            //arrange
            var target = new Program();
            var squares = new List<int>() { 8 };

            //act
            int actual = target.Score(squares);

            //assert
            Assert.AreEqual(8, actual);
        }

        [TestMethod]
        public void Score_Roll_8_9_ShouldReturn_17()
        {
            var target = new Program();
            var squares = new List<int>() { 8, 9 };

            var actual = target.Score(squares);
            Assert.AreEqual(17, actual);
        }

        //開始處理bonus計算邏輯
        //[TestMethod]
        //public void Score_Roll_10_3_ShouldReturn_16()
        //{
        //    var target = new Program();
        //    var squares = new List<int>() { 10, 3 };
        //    var actual = target.Score(squares);
        //    Assert.AreEqual(16, actual);
        //}
    }
}
