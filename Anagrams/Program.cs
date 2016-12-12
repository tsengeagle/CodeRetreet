using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        internal object GetPotentialAnagrams(string sInput)
        {
            throw new NotImplementedException();
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class PotentialAnagrams
    {
        [TestMethod]
        public void Input1Char()
        {
            //arrang
            var sInput = "A";
            var expected = "A";

            var target=new Program();
            
            //act   
            var actual = target.GetPotentialAnagrams(sInput);

            //assert
            Assert.AreEqual(expected,actual);

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