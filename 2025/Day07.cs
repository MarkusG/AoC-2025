using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day07 : AdventBase
{
    protected override object InternalPart1()
    {
        var beamCols = new HashSet<int> { Input.Lines[0].Index().First(x => x.Item == 'S').Index };

        var splits = 0;
        foreach (var l in Input.Lines[1..])
        {
            foreach (var (idx, c) in l.Index())
            {
                if (c == '^' && beamCols.Contains(idx))
                {
                    splits++;
                    beamCols.Remove(idx);
                    beamCols.Add(idx - 1);
                    beamCols.Add(idx + 1);
                }
            }
        }

        return splits;
    }

    protected override object InternalPart2()
    {
        var start = Input.Lines[0].Index().First(x => x.Item == 'S').Index;
        return CountPaths(1, start);
    }

    private readonly Dictionary<(int, int), long> _cache = new();

    private long CountPaths(int line, int col)
    {
        if (_cache.TryGetValue((line, col), out var cached))
            return cached;

        if (line == Input.Lines.Length - 1)
            return _cache[(line, col)] = 1;

        if (Input.Lines[line][col] == '.')
            return _cache[(line, col)] = CountPaths(line + 1, col);

        if (Input.Lines[line][col] == '^')
            return _cache[(line, col)] = CountPaths(line + 1, col - 1) + CountPaths(line + 1, col + 1);

        return 0;
    }
}