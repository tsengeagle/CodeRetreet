using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVSEvil
{

    //The function will be given two parameters.Each parameter will be a string separated by a single space.Each string will contain the count of each race on the side of good and evil.
    //The first parameter will contain the count of each race on the side of good in the following order:
    //Hobbits, Men, Elves, Dwarves, Eagles, Wizards.
    //The second parameter will contain the count of each race on the side of evil in the following order:
    //Orcs, Men, Wargs, Goblins, Uruk Hai, Trolls, Wizards.
    //All values are non-negative integers. The resulting sum of the worth for each side will not exceed the limit of a 32-bit integer.


    //Output:


    //Return ""Battle Result: Good triumphs over Evil" if good wins, "Battle Result: Evil eradicates all trace of Good" if evil wins, or "Battle Result: No victor on this battle field" if it ends in a tie.
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    class GoodVSEvilTests
    {
        [TestMethod]
        public void InputArmy_ShouldReturnGoodWin()
        {
            //arrange
            var good = "Hobbits, Men, Elves, Dwarves, Eagles, Wizards";
            var evil = "Orcs, Men, Wargs, Goblins, Uruk Hai, Trolls, Wizards";

            var target = new GoodVSEvil.Match();
            //act
            var result = target.GetResult(good, evil);

            //assert

            Assert.AreEqual("Battle Result: Good triumphs over Evil", result);
        }
    }

    internal class Match
    {
        public string GetResult(string good, string evil)
        {
            return "";
        }
    }
}
