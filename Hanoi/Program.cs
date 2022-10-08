public class Program
{
    public static void Main(string[] args)
    {
        HanoiTower hanoiTower = new HanoiTower(8);
        hanoiTower.Print();

        int count = HanoiTower.GetSolutionCount(8);
        foreach (var step in HanoiTower.GetSolution(HanoiTowerBase.C, 8))
        {
            Console.ReadKey(true);
            hanoiTower.Move(step.from, step.to);
            Console.SetCursorPosition(0, 0);
            hanoiTower.Print();

            count--;
            Console.WriteLine("还剩: {0:D3} 步", count);
        }

        while (true)
            Console.ReadKey(true);
    }
}