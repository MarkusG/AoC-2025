using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day11 : AdventBase
{
    protected override object InternalPart1()
    {
        var outs = new Dictionary<string, HashSet<string>>();

        foreach (var l in Input.Lines)
        {
            var src = l.Split(':')[0];
            var dests = l.Split(' ')[1..];

            outs[src] = dests.ToHashSet();
        }

        return GetPathsToOut1("you", outs);
    }

    private long GetPathsToOut1(string node, Dictionary<string, HashSet<string>> outs)
    {
        var paths = 0;
        if (node == "out")
            return 0;

        if (outs[node].Contains("out"))
            paths++;

        return paths + outs[node].Sum(n => GetPathsToOut1(n, outs));
    }

    protected override object InternalPart2()
    {
        var outs = new Dictionary<string, HashSet<string>>();

        foreach (var l in Input.Lines)
        {
            var src = l.Split(':')[0];
            var dests = l.Split(' ')[1..];

            outs[src] = dests.ToHashSet();
        }

        return GetPathsToOut2("svr", outs, false, false);
    }

    private readonly Dictionary<(string Node, bool Dac, bool Fft), long> _cache = new();

    private long GetPathsToOut2(string node, Dictionary<string, HashSet<string>> outs, bool dacVisited, bool fftVisited)
    {
        if (node == "out")
            return 0;

        if (_cache.TryGetValue((node, dacVisited, fftVisited), out var value))
            return value;

        var dac = dacVisited || node == "dac";
        var fft = fftVisited || node == "fft";

        var isValidTerminalNode = outs[node].Contains("out") && dacVisited && fftVisited ? 1 : 0;

        return isValidTerminalNode + outs[node].Sum(n => _cache[(n, dac, fft)] = GetPathsToOut2(n, outs, dac, fft));
    }
}