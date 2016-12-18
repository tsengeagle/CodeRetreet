using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace PotentialAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public string GetAnagrams(string sInput)
        {
            var result = "";
            result = sInput;

            if (sInput.Length > 1)
            {
                var fix = sInput.Remove(sInput.Length - 2);
                var sReverse = fix + Reverse(sInput.Remove(sInput.IndexOf(fix), 1));

                result += " " + Reverse(sInput);
            }


            return result;
        }

        private static string Reverse(string sInput)
        {
            var temp = "";
            for (int i = sInput.Length - 1; i >= 0; i--)
            {
                temp += sInput[i];
            }
            return temp;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class PotentialAnagramsTests
    {
        private Program _target;

        [TestMethod]
        public void Input1Char()
        {
            //arrange
            var sInput = "A";
            var expected = "A";

            _target = new Program();

            //act
            var actual = _target.GetAnagrams(sInput);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input2Char()
        {
            //arrange
            var sInput = "AB";
            var expected = "AB BA";

            _target = new Program();
            //act   
            var actual = _target.GetAnagrams(sInput);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Input3Char()
        {
            //arrange
            var sInput = "ABC";
            var expected = "ABC ACB BAC BCA CAB CBA";

            _target = new Program();
            //act   
            var actual = _target.GetAnagrams(sInput);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
//Write a program to generate all potential
//anagrams of an input string.

//For example, the potential anagrams of "biro" are

//biro bior brio broi boir bori
//ibro ibor irbo irob iobr iorb
//rbio rboi ribo riob roib robi
//obir obri oibr oirb orbi orib
