using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day06 : AdventBase
{
    protected override object InternalPart1()
    {
        var cols = Input.Lines[0].Split([' '], StringSplitOptions.RemoveEmptyEntries).Length;

        var results = new long[cols];

        var ops = Input.Lines.Last().Split([' '], StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in Input.Lines.Reverse().ToList()[1..])
        {
            var split = row.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < cols; i++)
            {
                if (ops[i] == "+")
                    results[i] += long.Parse(split[i]);
                else
                {
                    if (row != Input.Lines.Reverse().ToList()[1])
                        results[i] *= long.Parse(split[i]);
                    else
                        results[i] = long.Parse(split[i]);
                }
            }
        }

        return results.Sum();
    }

    protected override object InternalPart2()
    {
        var lines = Input.Lines.Reverse().ToList();

        var widths = new List<int>();

        var opIndices = lines[0]
            .Select((c, i) => new { c, i })
            .Where(x => x.c != ' ')
            .Select(x => x.i)
            .ToList();

        for (var i = 1; i <= opIndices.Count; i++)
        {
            if (i != opIndices.Count)
                widths.Add(opIndices[i] - opIndices[i - 1] - 1);
            else
                widths.Add(lines[0].Length - opIndices[^1]);
        }

        var ops = lines[0]
            .Select((c, i) => new { c, i })
            .Where(x => x.c != ' ')
            .Select(x => x.c)
            .ToList();

        long total = 0;

        var cursor = 0;
        for (var i = 0; i < widths.Count; i++)
        {
            var w = widths[i];
            var op = ops[i];

            var operands = new long[w];

            foreach (var l in Input.Lines[..^1])
            {
                for (var j = 0; j < w; j++)
                {
                    if (l[j + cursor] != ' ')
                    {
                        if (operands[j] != 0)
                            operands[j] *= 10;
                        operands[j] += l[j + cursor] - '0';
                    }
                }
            }

            if (op == '+')
                total += operands.Sum();
            else
                total += operands.Aggregate(1L, (c, n) => c * n);

            cursor += w + 1;
        }

        return total;
    }
}