using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GameOfLife
{
    [Binding]
    public class 細胞的下一秒Steps
    {
        [When(@"丟進一堆細胞，下一秒")]
        public void When丟進一堆細胞下一秒(Table inputCells)
        {
            var cells = inputCells.CreateSet<MyCell>().ToList();
            var target = new MyWorld();
            var result = target.NextSecont(cells);
            ScenarioContext.Current.Set<List<MyCell>>(result, "result");
        }

        [Then(@"剩下的細胞")]
        public void Then剩下的細胞(Table expectedCells)
        {
            var actualCells = ScenarioContext.Current.Get<List<MyCell>>("result");
            expectedCells.CompareToSet<MyCell>(actualCells);

        }
    }

    public class MyCell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool isAlive { get; set; }
        public override string ToString()
        {
            return string.Format("X:{0},Y:{1},status:{2}", this.X, this.Y, this.isAlive == true ? "活著" : "死掉");
        }
    }
}
