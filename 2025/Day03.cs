using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day03 : AdventBase
{
    protected override object InternalPart1()
    {
        var sum = 0;
        foreach (var l in Input.Lines)
        {
            var max = 0;
            for (var i = 0; i < l.Length; i++)
            {
                for (var j = i + 1; j < l.Length; j++)
                {
                    var joltage = 10 * (l[i] - 48) + l[j] - 48;
                    if (joltage > max) max = joltage;
                }
            }

            sum += max;
        }

        return sum;
    }

    protected override object InternalPart2()
    {
        long sum = 0;
        foreach (ReadOnlySpan<char> l in Input.Lines)
        {
            var digits = new int[12];
            var idx = 0;
            var bank = l;
            for (var i = 0; i < 12; i++)
            {
                bank = bank[idx..];
                var newIndex = GetNextIndex(bank, 11 - i);
                digits[i] = bank[newIndex] - 48;
                idx = newIndex + 1;
            }

            long joltage = 0;
            foreach (var t in digits)
            {
                joltage *= 10;
                joltage += t;
            }

            sum += joltage;
        }

        return sum;
    }

    private static int GetNextIndex(ReadOnlySpan<char> bank, int remainingDigits)
    {
        var idx = -1;

        for (var c = '9'; c >= '0'; c--)
        {
            if (!bank.Contains(c) || bank.Length - bank.IndexOf(c) <= remainingDigits) continue;
            idx = bank.IndexOf(c);
            break;
        }

        return idx;
    }
}