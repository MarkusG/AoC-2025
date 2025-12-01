using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day01 : AdventBase
{
    protected override object InternalPart1()
    {
        var pos = 50;
        var zeroes = 0;

        foreach (var l in Input.Lines)
        {
            if (l[0] == 'L')
                pos -= int.Parse(l.AsSpan()[1..]);
            else
                pos += int.Parse(l.AsSpan()[1..]);
            pos %= 100;
            if (pos == 0)
                zeroes++;
        }

        return zeroes;
    }

    protected override object InternalPart2()
    {
        var pos = 50;
        var zeroes = 0;

        foreach (var l in Input.Lines)
        {
            var magnitude = int.Parse(l.AsSpan()[1..]);
            var direction = 1;

            if (l[0] == 'L')
                direction = -1;

            zeroes += magnitude / 100;

            var magnitudeRem = magnitude % 100;

            var newPos = pos + magnitudeRem * direction;

            switch (newPos)
            {
                case > 99:
                    zeroes++;
                    pos = newPos % 100;
                    break;
                case 0:
                    zeroes++;
                    pos = newPos;
                    break;
                case < 0 when pos == 0:
                    pos = 100 + newPos;
                    break;
                case < 0:
                    zeroes++;
                    pos = 100 + newPos;
                    break;
                default:
                    pos = newPos;
                    break;
            }
        }

        return zeroes;
    }
}