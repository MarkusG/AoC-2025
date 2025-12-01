using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day01 : AdventBase
{
    protected override object InternalPart1()
    {
        var lines = Input.Lines;
        var pos = 50;
        var zeroes = 0;
        
        foreach (var l in lines)
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
        var lines = Input.Lines;
        var pos = 50;
        var zeroes = 0;
        foreach (var l in lines)
        {
            var magnitude = int.Parse(l[1..]);
            var direction = 1;
            if (l[0] == 'L')
                direction = -1;
            
            // fuck it
            for (var i = 0; i < magnitude; i++)
            {
                pos += direction;

                if (pos == 100)
                    pos = 0;
                
                if (pos == 0)
                    zeroes++;

                if (pos == -1)
                    pos = 99;
            }
        }

        return zeroes;
    }
}