# Hanoi

简单的, 解汉诺塔的一个小程序 (递归实现)

```
        |                     |                     |
        |                     |                     |
        |                     |                     |
        |                     |                     |
       #|#                    |                     |
  ######|######               |                     |
 #######|#######            ##|##                ###|###
########|########        #####|#####            ####|####
还剩: 237 步
```

## 使用姿势

```csharp
// 新建一个八层高的汉诺塔
HanoiTower hanoiTower = new HanoiTower(8);

// 可以通过静态方法获取 n 层汉诺塔解开需要的部属
int count = HanoiTower.GetSolutionCount(8);

// 通过静态方法获取 n 层汉诺塔, 移动到指定位置所需要的步骤
var steps = HanoiTower.GetSolution(HanoiTowerBase.C, 8)

// 遍历所有步骤
foreach (var step in steps)
{
    Console.ReadKey(true);                        // 等待用户按下一个按键
    hanoiTower.Move(step.from, step.to);          // 执行一步

    Console.SetCursorPosition(0, 0);              // 控制台光标移动到 0, 0
    hanoiTower.Print();                           // 打印当前汉诺塔到控制台

    count--;
    Console.WriteLine("还剩: {0:D3} 步", count);
}

```