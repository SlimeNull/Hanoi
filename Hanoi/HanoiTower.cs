using System.Drawing;
using System.Text;

public class HanoiTower
{
    private Stack<int>[] bases;

    public HanoiTower(int level)
    {
        bases = new Stack<int>[3];
        bases[0] = new Stack<int>();
        bases[1] = new Stack<int>();
        bases[2] = new Stack<int>();

        Stack<int> baseA = bases[0];
        for (int i = level; i > 0; i--)
        {
            baseA.Push(i);
        }
        Level = level;
    }

    public int Level { get; }

    public void Move(HanoiTowerBase from, HanoiTowerBase to)
    {
        Stack<int> fromBase = bases[(int)from];
        Stack<int> toBase = bases[(int)to];
        if (fromBase.TryPeek(out int fromValue) && (toBase.TryPeek(out int toValue) ? toValue == 0 || fromValue < toValue : true))
        {
            fromBase.Pop();
            toBase.Push(fromValue);
            return;
        }

        throw new InvalidOperationException();
    }

    public void Print()
    {
        static IEnumerable<string> BuildTower(Stack<int> towerBase, int level)
        {
            int emptyCount = level - towerBase.Count;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < emptyCount; i++)
            {
                sb.Clear();
                sb.Append(' ', level);
                sb.Append('|');
                sb.Append(' ', level);
                yield return sb.ToString();
            }
            foreach (int floor in towerBase)
            {
                sb.Clear();
                sb.Append(' ', level - floor);
                sb.Append('#', floor);
                sb.Append('|');
                sb.Append('#', floor);
                sb.Append(' ', level - floor);
                yield return sb.ToString();
            }
        }

        IEnumerable<string> threeTowers = BuildTower(bases[0], Level)
            .Zip(BuildTower(bases[1], Level), (a, b) => string.Join(@"     ", a, b))
            .Zip(BuildTower(bases[2], Level), (a, b) => string.Join(@"     ", a, b));

        foreach (var floor in threeTowers)
        {
            Console.WriteLine(floor);
        }
    }

    public static HanoiTowerBase GetOtherBase(HanoiTowerBase a, HanoiTowerBase b)
    {
        return (HanoiTowerBase)(3 - (int)a - (int)b);
    }

    public static IEnumerable<(HanoiTowerBase from, HanoiTowerBase to)> GetSolution(HanoiTowerBase to, int level)
    {
        IEnumerable<(HanoiTowerBase from, HanoiTowerBase to)> Move(HanoiTowerBase from, HanoiTowerBase to, int height)
        {
            if (height == 1)
            {
                yield return (from, to);
            }
            else if (height > 1)
            {
                HanoiTowerBase other = GetOtherBase(from, to);
                foreach (var step in Move(from, other, height - 1))
                    yield return step;
                yield return (from, to);
                foreach (var step in Move(other, to, height - 1))
                    yield return step;
            }
        }

        if (HanoiTowerBase.A == to)
            yield break;

        foreach (var step in Move(HanoiTowerBase.A, to, level))
            yield return step;
    }

    public static int GetSolutionCount(int level)
    {
        if (level == 1)
            return 1;
        else
            return GetSolutionCount(level - 1) * 2 + 1;
    }
}
