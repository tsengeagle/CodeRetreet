using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GameOfLife
{
    [Binding]
    public class 細胞的下一秒Steps
    {
        [When(@"細胞 (.*)")]
        public void When細胞(string cells)
        {
            var targat = new Program();
            var result = targat.NextSecond(cells);
            ScenarioContext.Current.Set<string>(result, "result");
        }

        [Then(@"顯示 (.*)")]
        public void Then顯示(string expected)
        {
            var actual = ScenarioContext.Current.Get<string>("result");
            Assert.AreEqual(expected, actual);
        }
    }
}
