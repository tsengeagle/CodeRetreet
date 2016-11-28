using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    internal class MyWorld
    {
        public List<MyCell> NextSecont(List<MyCell> cells)
        {
            //一開始  =>  下一秒
            //   X
            //   0123       0123
            //Y0 0110       0010
            // 1 0001       0000
            // 2 0000       0000
            var result = new List<MyCell>();
            foreach (var myCell in cells)
            {
                var newCell = new MyCell() { X = myCell.X, Y = myCell.Y, isAlive = myCell.isAlive };

                var liveCnt = 0;
                for (int neighberX = myCell.X - 1; neighberX <= myCell.X + 1; neighberX++)
                {
                    for (int neighberY = myCell.Y - 1; neighberY <= myCell.Y + 1; neighberY++)
                    {
                        if (neighberX == myCell.X && neighberY == myCell.Y)
                        {

                        }
                        else
                        {
                            var neighberCell = cells.Where(w => (w.X == neighberX && w.Y == neighberY))
                            .FirstOrDefault();
                            if (neighberCell != null && neighberCell.isAlive)
                            {
                                liveCnt += 1;
                            }
                        }

                    }
                }
                //1.當前細胞為存活狀態時，當周圍低於2個（不包含2個）存活細胞時， 該細胞變成死亡狀態。（模擬生命數量稀少）
                //2.當前細胞為存活狀態時，當周圍有2個或3個存活細胞時， 該細胞保持原樣。
                //3.當前細胞為存活狀態時，當周圍有3個以上的存活細胞時，該細胞變成死亡狀態。（模擬生命數量過多）
                //4.當前細胞為死亡狀態時，當周圍有3個存活細胞時，該細胞變成存活狀態。 （模擬繁殖）
                if (myCell.isAlive)
                {
                    if (liveCnt < 2)
                    {
                        newCell.isAlive = false;
                    }
                    else if (liveCnt >= 2 && liveCnt <= 3)
                    {

                    }
                    else if (liveCnt > 3)
                    {
                        newCell.isAlive = false;
                    }
                }
                else
                {
                    if (liveCnt == 3)
                    {
                        newCell.isAlive = true;
                    }
                }
                result.Add(newCell);
            }
            return result;
        }
    }
}