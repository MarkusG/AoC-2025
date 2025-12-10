using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day09 : AdventBase
{
    protected override object InternalPart1()
    {
        var points = new HashSet<(long X, long Y)>();

        foreach (var l in Input.Lines)
        {
            var split = l.Split(',');

            var x = int.Parse(split[0]);
            var y = int.Parse(split[1]);

            points.Add((x, y));
        }

        long maxArea = 0;
        foreach (var p1 in points)
        {
            foreach (var p2 in points)
            {
                long area = Math.Abs((p1.X - p2.X + 1) * (p1.Y - p2.Y + 1));
                if (area > maxArea)
                    maxArea = area;
            }
        }

        return maxArea;
    }

    protected override object InternalPart2()
    {
        var points = new HashSet<(int X, int Y)>();

        foreach (var l in Input.Lines)
        {
            var split = l.Split(',');

            var x = int.Parse(split[0]);
            var y = int.Parse(split[1]);

            points.Add((x, y));
        }

        long maxArea = 0;
        foreach (var p1 in points)
        {
            foreach (var p2 in points)
            {
                var width = Math.Abs(p1.X - p2.X);
                var height = Math.Abs(p1.Y - p2.Y);

                var grid = new char[width][];
                for (var i = 0; i < width; i++)
                    grid[i] = new string('.', height).ToCharArray();
                
                long area = Math.Abs((long)(p1.X - p2.X + 1) * (p1.Y - p2.Y + 1));
                if (area > maxArea)
                    maxArea = area;
            }
        }

        return maxArea;
    }
}