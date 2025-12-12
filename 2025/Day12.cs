using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day12 : AdventBase
{
    protected override object InternalPart1()
    {
        var regions = Input.Blocks.Last();
        var count = 0;
        foreach (var r in regions.Lines)
        {
            var x = int.Parse(r[..2]);
            var y = int.Parse(r[3..5]);
            long area = x * y;

            var presentCounts = r.Split(' ')[1..].Select(long.Parse).ToArray();
            var occupiedSquares = 7 * presentCounts[0] +
                                  7 * presentCounts[1] +
                                  7 * presentCounts[2] +
                                  7 * presentCounts[3] +
                                  6 * presentCounts[4] +
                                  5 * presentCounts[5];

            if (area > occupiedSquares)
                count++;
        }

        return count;
    }

    protected override object InternalPart2()
    {
        return 0;
    }
}