using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        internal Cell PutIn(Cell cell)
        {
            cell.isAlive = false;
            return cell;
        }
    }

    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class GameOfLifeTests
    {
        [TestMethod]
        public void SingleCellShouldDie()
        {
            var cell = new Cell(1, 1);
            var target=new Program();

            var result = target.PutIn(cell);

            Assert.IsFalse(result.isAlive);
        }   
    }

    internal class Cell
    {
        private int _x;
        private int _y;

        public Cell(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public bool isAlive { get; internal set; }
    }
}
