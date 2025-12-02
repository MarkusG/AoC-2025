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

        ulong sum = 0;

        foreach (var r in ranges)
        {
            for (var i = r.Item1; i <= r.Item2; i++)
            {
                var digits = Math.Floor(Math.Log10(i) + 1);
                if (digits % 2 != 0)
                    continue;

                var divisor = (int)Math.Pow(10, digits / 2);

                if (i % divisor == i / divisor)
                    sum += (ulong)i;
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
                var @string = i.ToString();

                var invalid = false;
                for (var j = @string.Length - 1; j > 0; j--)
                {
                    if (@string.Length % j != 0)
                        continue;

                    var chunks = @string.Chunk(j).Select(chunk => new string(chunk)).ToList();

                    var initialChunk = chunks[0];
                    foreach (var chunk in chunks[1..])
                    {
                        if (chunk != initialChunk)
                            goto notThisChunkSize;
                    }

                    invalid = true;
                    notThisChunkSize: ;
                }

                if (invalid)
                    sum += i;
            }
        }


        return sum;
    }
}