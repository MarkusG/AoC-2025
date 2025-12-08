using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day08 : AdventBase
{
    protected override object InternalPart1()
    {
        var boxes = new List<(int X, int Y, int Z)>();
        foreach (var l in Input.Lines)
        {
            var xyz = l.Split(',');
            boxes.Add((int.Parse(xyz[0]), int.Parse(xyz[1]), int.Parse(xyz[2])));
        }

        var distances = new Dictionary<((int X, int Y, int Z), (int X, int Y, int Z)), double>();

        foreach (var b1 in boxes)
        {
            foreach (var b2 in boxes)
            {
                if (b1 == b2)
                    continue;

                if (distances.ContainsKey((b1, b2)) || distances.ContainsKey((b2, b1)))
                    continue;

                distances.Add((b1, b2), Math.Sqrt(
                    Math.Pow(b1.X - b2.X, 2) +
                    Math.Pow(b1.Y - b2.Y, 2) +
                    Math.Pow(b1.Z - b2.Z, 2)
                ));
            }
        }

        var connections = distances
            .OrderBy(kv => kv.Value)
            .Take(1000)
            .Select(kv => (kv.Key.Item1, kv.Key.Item2))
            .ToList();

        var circuits = new Dictionary<(int X, int Y, int Z), HashSet<(int X, int Y, int Z)>>();

        foreach (var c in connections)
        {
            var circuit1 = circuits.GetValueOrDefault(c.Item1);
            var circuit2 = circuits.GetValueOrDefault(c.Item2);

            var circuit = (circuit1, circuit2) switch
            {
                (null, null) => new HashSet<(int X, int Y, int Z)> { c.Item1, c.Item2 },
                ({ } c1, null) => c1,
                (null, { } c2) => c2,
                ({ } c1, { } c2) => new HashSet<(int X, int Y, int Z)>([..c1, ..c2])
            };

            circuit.UnionWith([c.Item1, c.Item2]);

            foreach (var b in circuit)
                circuits[b] = circuit;
        }

        var sizes = circuits.Values
            .Distinct()
            .Select(v => v.Count)
            .OrderByDescending(c => c)
            .Take(3)
            .ToList();
        
        return sizes.Aggregate(1, (c, n) => c * n);
    }

    protected override object InternalPart2()
    {
        var boxes = new List<(int X, int Y, int Z)>();
        foreach (var l in Input.Lines)
        {
            var xyz = l.Split(',');
            boxes.Add((int.Parse(xyz[0]), int.Parse(xyz[1]), int.Parse(xyz[2])));
        }

        var distances = new Dictionary<((int X, int Y, int Z), (int X, int Y, int Z)), double>();

        foreach (var b1 in boxes)
        {
            foreach (var b2 in boxes)
            {
                if (b1 == b2)
                    continue;

                if (distances.ContainsKey((b1, b2)) || distances.ContainsKey((b2, b1)))
                    continue;

                distances.Add((b1, b2), Math.Sqrt(
                    Math.Pow(b1.X - b2.X, 2) +
                    Math.Pow(b1.Y - b2.Y, 2) +
                    Math.Pow(b1.Z - b2.Z, 2)
                ));
            }
        }

        var connections = distances
            .OrderBy(kv => kv.Value)
            .Select(kv => (kv.Key.Item1, kv.Key.Item2))
            .ToList();

        var circuits = new Dictionary<(int X, int Y, int Z), HashSet<(int X, int Y, int Z)>>();

        foreach (var c in connections)
        {
            var circuit1 = circuits.GetValueOrDefault(c.Item1);
            var circuit2 = circuits.GetValueOrDefault(c.Item2);

            var circuit = (circuit1, circuit2) switch
            {
                (null, null) => new HashSet<(int X, int Y, int Z)> { c.Item1, c.Item2 },
                ({ } c1, null) => c1,
                (null, { } c2) => c2,
                ({ } c1, { } c2) => new HashSet<(int X, int Y, int Z)>([..c1, ..c2])
            };

            circuit.UnionWith([c.Item1, c.Item2]);

            foreach (var b in circuit)
                circuits[b] = circuit;
            
            if (circuits.Keys.Count == 1000 && circuits.Values.Distinct().Count() == 1)
                return (long)c.Item1.X * (long)c.Item2.X;
        }

        return -1;
    }
}