using System;
using System.Linq;

namespace GameOfLife
{
    public class Program
    {
        public static void Main()
        {

        }

        public string NextSecond(string cells)
        {
            var result = "";
            //當前細胞為存活狀態時，當周圍低於2個（不包含2個）存活細胞時， 該細胞變成死亡狀態。（模擬生命數量稀少）
            for (int i = 0; i < cells.Length; i++)
            {
                var currentCell = cells.ToArray()[i].ToString();
                if (currentCell == "1")
                {
                    var neightberCnt = 0;
                    if (i > 1)
                    {
                        var preCell = cells.ToArray()[i - 1].ToString();
                        if (preCell == "1")
                        {
                            neightberCnt += 1;
                        }
                    }
                    if (i < cells.Length-1)
                    {
                        var nextCell = cells.ToArray()[i + 1].ToString();
                        if (nextCell == "1")
                        {
                            neightberCnt += 1;
                        }
                    }
                    if (neightberCnt < 2)
                    {
                        result += "0";
                    }else if (neightberCnt>=2)
                    {
                        result += "1";
                    }

                }
                else
                {
                    result += currentCell;
                }

            }

            return result;
        }
    }
}