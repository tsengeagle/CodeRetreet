Feature: 細胞的下一秒
https://zh.wikipedia.org/wiki/%E5%BA%B7%E5%A8%81%E7%94%9F%E5%91%BD%E6%B8%B8%E6%88%8F
1.當前細胞為存活狀態時，當周圍低於2個（不包含2個）存活細胞時， 該細胞變成死亡狀態。（模擬生命數量稀少）
2.當前細胞為存活狀態時，當周圍有2個或3個存活細胞時， 該細胞保持原樣。
3.當前細胞為存活狀態時，當周圍有3個以上的存活細胞時，該細胞變成死亡狀態。（模擬生命數量過多）
4.當前細胞為死亡狀態時，當周圍有3個存活細胞時，該細胞變成存活狀態。 （模擬繁殖）

有一個世界(範圍)，丟進一些細胞，看他下一秒發生甚麼事情

//一開始  =>  下一秒
//   X
//   0123       0123
//Y0 0110       0010
// 1 0001       0010
// 2 0000       0000

//一開始  =>  下一秒
//   X
//   0123       0123
//Y0 0110       0010
// 1 0001       0010
// 2 0000       0000
// 3 1000       0000


Scenario: 丟三個細胞進去
When 丟進一堆細胞，下一秒
 | X | Y | isAlive |
 | 0 | 0 | false   |
 | 1 | 0 | true    |
 | 2 | 0 | true    |
 | 3 | 0 | false   |
 | 0 | 1 | false   |
 | 1 | 1 | false   |
 | 2 | 1 | false   |
 | 3 | 1 | true    |
 | 0 | 2 | false   |
 | 1 | 2 | false   |
 | 2 | 2 | false   |
 | 3 | 2 | false   |
Then 剩下的細胞
 | X | Y | isAlive |
 | 0 | 0 | false   |
 | 1 | 0 | false   |
 | 2 | 0 | true    |
 | 3 | 0 | false   |
 | 0 | 1 | false   |
 | 1 | 1 | false   |
 | 2 | 1 | true    |
 | 3 | 1 | false   |
 | 0 | 2 | false   |
 | 1 | 2 | false   |
 | 2 | 2 | false   |
 | 3 | 2 | false   |


 Scenario: 丟四個細胞進去
 When 丟進一堆細胞，下一秒
 | X | Y | isAlive |
 | 0 | 0 | false   |
 | 1 | 0 | true    |
 | 2 | 0 | true    |
 | 3 | 0 | false   |
 | 0 | 1 | false   |
 | 1 | 1 | false   |
 | 2 | 1 | false   |
 | 3 | 1 | true    |
 | 0 | 2 | false   |
 | 1 | 2 | false   |
 | 2 | 2 | false   |
 | 3 | 2 | false   |
 | 0 | 3 | true    |
 | 1 | 3 | false   |
 | 2 | 3 | false   |
 | 3 | 3 | false   |
Then 剩下的細胞
 | X | Y | isAlive |
 | 0 | 0 | false   |
 | 1 | 0 | false   |
 | 2 | 0 | true    |
 | 3 | 0 | false   |
 | 0 | 1 | false   |
 | 1 | 1 | false   |
 | 2 | 1 | true    |
 | 3 | 1 | false   |
 | 0 | 2 | false   |
 | 1 | 2 | false   |
 | 2 | 2 | false   |
 | 3 | 2 | false   |
 | 0 | 3 | false   |
 | 1 | 3 | false   |
 | 2 | 3 | false   |
 | 3 | 3 | false   |
