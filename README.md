# Hanoi

�򵥵�, �⺺ŵ����һ��С���� (�ݹ�ʵ��)

```
        |                     |                     |
        |                     |                     |
        |                     |                     |
        |                     |                     |
       #|#                    |                     |
  ######|######               |                     |
 #######|#######            ##|##                ###|###
########|########        #####|#####            ####|####
��ʣ: 237 ��
```

## ʹ������

```csharp
// �½�һ���˲�ߵĺ�ŵ��
HanoiTower hanoiTower = new HanoiTower(8);

// ����ͨ����̬������ȡ n �㺺ŵ���⿪��Ҫ�Ĳ���
int count = HanoiTower.GetSolutionCount(8);

// ͨ����̬������ȡ n �㺺ŵ��, �ƶ���ָ��λ������Ҫ�Ĳ���
var steps = HanoiTower.GetSolution(HanoiTowerBase.C, 8)

// �������в���
foreach (var step in steps)
{
    Console.ReadKey(true);                        // �ȴ��û�����һ������
    hanoiTower.Move(step.from, step.to);          // ִ��һ��

    Console.SetCursorPosition(0, 0);              // ����̨����ƶ��� 0, 0
    hanoiTower.Print();                           // ��ӡ��ǰ��ŵ��������̨

    count--;
    Console.WriteLine("��ʣ: {0:D3} ��", count);
}

```