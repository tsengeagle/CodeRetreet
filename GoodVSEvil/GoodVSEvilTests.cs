using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;

namespace GoodVSEvil
{

    //Middle Earth is about to go to war.The forces of good will have many battles with the forces of evil.Different races will certainly be involved.Each race has a certain 'worth' when battling against others. On the side of army we have the following races, with their associated worth:
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

        [TestMethod]
        public void InputMultiRace_ShouldReturnEvilWin()
        {
            //arrange
            var good = "Hobbits, Men, Elves, Dwarves, Eagles, Wizards"; //1+2+3+3+4+10=23
            var evil = "Orcs, Men, Wargs, Goblins, Uruk Hai, Trolls, Wizards"; //1+2+2+2+3+5+10=25

            var target = new GoodVSEvil.Match();
            //act
            var result = target.GetResult(good, evil);

            //assert

            Assert.AreEqual("Battle Result: Evil eradicates all trace of Good", result);
        }

        [TestMethod]
        public void InputMultyRace_ShouldReturnNobodyWin()
        {
            //arrange
            var good = "Elves, Dwarves, Eagles"; //3+3+4=10
            var evil = "Goblins, Uruk Hai, Trolls"; //2+3+5=10

            var target = new GoodVSEvil.Match();
            //act
            var result = target.GetResult(good, evil);

            //assert

            Assert.AreEqual("Battle Result: No victor on this battle field", result);

        }

        [TestMethod]
        public void InputString_ShouldReturn23()
        {
            //arrange
            var army = "Hobbits, Men, Elves, Dwarves, Eagles, Wizards"; //1+2+3+3+4+10=23
            var expected = 23;
            var target = new GoodVSEvil.Match();

            //act
            var actual = target.GetArmyScore(army);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputString_ShouldReturn13()
        {
            //arrange
            var army = "Hobbits, Men, Elves, Dwarves, Eagles"; //1+2+3+3+4=13
            var expected = 13;
            var target = new GoodVSEvil.Match();

            //act
            var actual = target.GetArmyScore(army);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InputString_ShouldReturn15()
        {
            //arrange
            var army = "Orcs, Men, Wargs, Goblins, Uruk Hai, Trolls"; //1+2+2+2+3+5=15
            var expected = 15;
            var target = new GoodVSEvil.Match();

            //act
            var actual = target.GetArmyScore(army);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }

    internal class Match
    {
        public string GetResult(string good, string evil)
        {
            var goodScore = GetArmyScore(good);
            var evilScore = GetArmyScore(evil);

            if (goodScore > evilScore)
            {
                return "Battle Result: Good triumphs over Evil";

            }
            else if (evilScore > goodScore)
            {
                return "Battle Result: Evil eradicates all trace of Good";
            }
            else
            {
                return "Battle Result: No victor on this battle field";
            }

        }

        public int GetArmyScore(string army)
        {
            var result = 0;
            var armys = army.Split(',');
            foreach (var item in armys)
            {
                if (item.Trim() == "Hobbits")
                {
                    result += 1;
                }
                if (item.Trim() == "Men")
                {
                    result += 2;
                }
                if (item.Trim() == "Elves")
                {
                    result += 3;
                }
                if (item.Trim() == "Dwarves")
                {
                    result += 3;
                }
                if (item.Trim() == "Eagles")
                {
                    result += 4;
                }
                if (item.Trim() == "Wizards")
                {
                    result += 10;
                }
                if (item.Trim() == "Orcs")
                {
                    result += 1;
                }
                if (item.Trim() == "Wargs")
                {
                    result += 2;
                }
                if (item.Trim() == "Goblins")
                {
                    result += 2;
                }
                if (item.Trim() == "Uruk Hai")
                {
                    result += 3;
                }
                if (item.Trim() == "Trolls")
                {
                    result += 5;
                }

            }
            return result;
        }
    }
}
