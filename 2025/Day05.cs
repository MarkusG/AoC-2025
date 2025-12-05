using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day05 : AdventBase
{
    protected override object InternalPart1()
    {
        var fresh = Input.Blocks[0].Lines;
        var ingredients = Input.Blocks[1].Lines;
        var count = 0;
        foreach (var i in ingredients)
        {
            var num = long.Parse(i);
            var isFresh = false;
            foreach (var f in fresh)
            {
                var one = f.Split('-')[0];
                var two = f.Split('-')[1];
                if (num >= long.Parse(one) && num <= long.Parse(two))
                    isFresh = true;
            }

            if (isFresh)
                count++;
        }

        return count;
    }

    protected override object InternalPart2()
    {
        var fresh = Input.Blocks[0].Lines;
        long count = 0;

        var ranges = new List<(long Low, long High)>();
        var lows = new HashSet<long>();
        var highs = new HashSet<long>();
        foreach (var f in fresh)
        {
            var one = long.Parse(f.Split('-')[0]);
            var two = long.Parse(f.Split('-')[1]);

            lows.Add(one);
            highs.Add(two);
            ranges.Add((one, two));
        }

        ranges.Sort((x, y) => x.Low < y.Low ? -1 : x.Low == y.Low ? 0 : 1);

        var flatRangesSet = new HashSet<(long Low, long High)>();
        var cursor = 0;

        var low = ranges[cursor].Low;
        var high = ranges[cursor].High;

        do
        {
            var intersectingRange = ranges[(cursor + 1)..].FirstOrDefault(r => r.Low <= high);

            // disconnected range
            if (intersectingRange == default)
            {
                flatRangesSet.Add((low, high));
                if (cursor < ranges.Count - 1)
                {
                    low = ranges[cursor + 1].Low;
                    high = ranges[cursor + 1].High;
                }
            }
            else if (intersectingRange.High > high)
                high = intersectingRange.High;

            cursor++;
        } while (flatRangesSet.Count == 0 || flatRangesSet.Last().High != ranges.Last().High);

        foreach (var r in flatRangesSet)
            count += r.High - r.Low + 1;

        return count;
    }
}