using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day02 : AdventBase
{
    protected override object InternalPart1()
    {
        var input = Input.Text;
        var ranges = input.Split(',')
            .Select(r => r.Split('-'))
            .Select(r => (long.Parse(r[0]), long.Parse(r[1])));

        long sum = 0;

        foreach (var r in ranges)
        {
            for (var i = r.Item1; i <= r.Item2; i++)
            {
                if (i is >= 10 and < 100 && i % 11 == 0)
                    sum += i;
                else if (i is >= 1_000 and < 10_000 && i % 101 == 0)
                    sum += i;
                else if (i is >= 100_000 and < 1_000_000 && i % 1001 == 0)
                    sum += i;
                else if (i is >= 10_000_000 and < 100_000_000 && i % 10001 == 0)
                    sum += i;
                else if (i is >= 1_000_000_000 and < 10_000_000_000 && i % 100001 == 0)
                    sum += i;
            }
        }

        return sum;
    }

    protected override object InternalPart2()
    {
        var input = Input.Text;
        var ranges = input.Split(',')
            .Select(r => r.Split('-'))
            .Select(r => (long.Parse(r[0]), long.Parse(r[1])));

        long sum = 0;

        foreach (var r in ranges)
        {
            for (var i = r.Item1; i <= r.Item2; i++)
            {
                if (i is >= 10 and < 100
                    // 1 digit repeated 2
                    && i % 11 == 0)
                    sum += i;
                else if (i is >= 100 and < 1_000
                         // 1 digit repeated 3
                         && i % 111 == 0)
                    sum += i;
                else if (i is > 1_000 and < 10_000 && (
                             // 1 digit repeated 4
                             i % 1111 == 0
                             // 2 digit repeated 2
                             || i % 101 == 0))
                    sum += i;
                else if (i is >= 10_000 and < 100_000 &&
                         // 1 digit repeated 5
                         i % 11111 == 0)
                    sum += i;
                else if (i is >= 100_000 and < 1_000_000 &&
                         // 1 digit repeated 6
                         (i % 111111 == 0
                          // 2 digit repeated 3
                          || i % 10101 == 0
                          // 3 digit repeated 2
                          || i % 1001 == 0))
                    sum += i;
                else if (i is >= 1_000_000 and < 10_000_000 &&
                         // 1 digit repeated 7
                         i % 1111111 == 0)
                    sum += i;
                else if (i is >= 10_000_000 and < 100_000_000 && (
                             // 1 digit repeated 8
                             i % 11111111 == 0
                             // 2 digit repeated 4
                             || i % 1010101 == 0
                             // 4 digit repeated 2
                             || i % 10001 == 0))
                    sum += i;
                else if (i is >= 100_000_000 and < 1_000_000_000 && (
                             // 1 digit repeated 9
                             i % 111111111 == 0
                             // 3 digit repeated 3
                             || i % 1001001 == 0
                         ))
                    sum += i;
                else if (i is >= 1_000_000_000 and < 10_000_000_000 && (
                             // 1 digit repeated 10
                             i % 1111111111 == 0
                             // 2 digit repeated 5
                             || i % 101010101 == 0
                             // 5 digit repeated 2
                             || i % 100001 == 0
                         ))
                    sum += i;
            }
        }

        return sum;
    }
}