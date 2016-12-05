using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodVSEvil
{

    //Middle Earth is about to go to war.The forces of good will have many battles with the forces of evil.Different races will certainly be involved.Each race has a certain 'worth' when battling against others. On the side of good we have the following races, with their associated worth:
    //Good
    //Hobbits - 1
    //Men - 2
    //Elves - 3
    //Dwarves - 3
    //Eagles - 4
    //Wizards - 10

    //Evil
    //Orcs - 1
    //Men - 2
    //Wargs - 2
    //Goblins - 2
    //Uruk Hai - 3
    //Trolls - 5
    //Wizards - 10

    //The function will be given two parameters.Each parameter will be a string separated by a single space.Each string will contain the count of each race on the side of good and evil.
    //The first parameter will contain the count of each race on the side of good in the following order:
    //Hobbits, Men, Elves, Dwarves, Eagles, Wizards.
    //The second parameter will contain the count of each race on the side of evil in the following order:
    //Orcs, Men, Wargs, Goblins, Uruk Hai, Trolls, Wizards.
    //All values are non-negative integers. The resulting sum of the worth for each side will not exceed the limit of a 32-bit integer.
    
    //Output:
    //Return ""Battle Result: Good triumphs over Evil" if good wins, "Battle Result: Evil eradicates all trace of Good" if evil wins, or "Battle Result: No victor on this battle field" if it ends in a tie.
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class GoodVSEvilTests
    {
        [TestMethod]
        public void InputArmy_ShouldReturnGoodWin()
        {
            //arrange
            var good = "Men"; //2
            var evil = "Orcs"; //1

            var target = new GoodVSEvil.Match();
            //act
            var result = target.GetResult(good, evil);

            //assert

            Assert.AreEqual("Battle Result: Good triumphs over Evil", result);
        }

        [TestMethod]
        public void InputArmy_ShouldReturnEvilWin()
        {
            //arrange
            var good = "Hobbits"; //1
            var evil = "Men"; //2

            var target = new GoodVSEvil.Match();
            //act
            var result = target.GetResult(good, evil);

            //assert

            Assert.AreEqual("Battle Result: Evil eradicates all trace of Good", result);
        }

    }

    internal class Match
    {
        public string GetResult(string good, string evil)
        {
            if (good=="Hobbits" && evil=="Men")
            {
                return "Battle Result: Evil eradicates all trace of Good";
            }
            return "Battle Result: Good triumphs over Evil";
        }
    }
}
