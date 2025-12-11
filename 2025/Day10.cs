using AdventOfCodeSupport;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;

namespace AoC_2025._2025;

public class Day10 : AdventBase
{
    public class Machine
    {
        public bool[] Lights { get; set; } = [];

        public List<HashSet<int>> Buttons { get; set; } = [];
    }

    protected override object InternalPart1()
    {
        var total = 0;
        foreach (var l in Input.Lines)
        {
            var cursor = 1;
            var lightEnd = l.IndexOf(']');

            var machine = new Machine
            {
                Lights = new bool[lightEnd - 1]
            };

            while (l[cursor] != ']')
            {
                machine.Lights[cursor - 1] = l[cursor] != '.';
                cursor++;
            }

            var buttons = l[(lightEnd + 2)..].Split(' ')[..^1];
            foreach (var b in buttons)
                machine.Buttons.Add(b[1..^1].Split(',').Select(i => machine.Lights.Length - int.Parse(i) - 1).ToHashSet());

            var states = new HashSet<uint>([0]);
            var edges = new HashSet<(uint Initial, uint After)>();

            var added = 0;
            do
            {
                foreach (var b in machine.Buttons)
                {
                    added = 0;
                    foreach (var state in states.ToList())
                    {
                        var newState = state;

                        foreach (var place in b)
                            newState ^= (uint)1 << place;


                        states.Add(newState);
                        added += edges.Add((state, newState)) ? 1 : 0;
                    }
                }
            } while (added != 0);

            var q = new HashSet<uint>();
            var distances = new Dictionary<uint, long>();
            var prev = new Dictionary<uint, uint>();

            foreach (var s in states)
            {
                distances[s] = long.MaxValue;
                q.Add(s);
            }

            distances[0] = 0;

            while (q.Count > 0)
            {
                var u = q.MinBy(s => distances[s]);
                q.Remove(u);

                foreach (var v in q)
                {
                    var alt = edges.Contains((u, v)) ? distances[u] + 1 : long.MaxValue;
                    if (alt < distances[v])
                    {
                        distances[v] = alt;
                        prev[v] = u;
                    }
                }
            }

            var stack = new Stack<uint>();
            uint node = 0;
            for (var i = 0; i < machine.Lights.Length; i++)
            {
                if (machine.Lights[i])
                    node |= (uint)1 << (machine.Lights.Length - i - 1);
            }

            while (true)
            {
                stack.Push(node);
                if (!prev.TryGetValue(node, out var newNode))
                    break;
                node = newNode;
            }

            total += stack.Count - 1;
        }

        return total;
    }

    public class Machine2
    {
        public bool[] Lights { get; set; } = [];

        public List<List<int>> Buttons { get; set; } = [];

        public double[] Joltages { get; set; } = [];
    }

    protected override object InternalPart2()
    {
        var total = 0;
        foreach (var l in Input.Lines)
        {
            var cursor = 1;
            var lightEnd = l.IndexOf(']');

            var machine = new Machine2
            {
                Lights = new bool[lightEnd - 1]
            };

            while (l[cursor] != ']')
            {
                machine.Lights[cursor - 1] = l[cursor] != '.';
                cursor++;
            }

            var secondSplit = l[(lightEnd + 2)..].Split(' ');
            var buttons = secondSplit[..^1];
            foreach (var b in buttons)
                machine.Buttons.Add(b[1..^1].Split(',').Select(int.Parse).ToList());

            var joltageBlock = secondSplit[^1];
            var joltages = joltageBlock[1..^1].Split(',').Select(int.Parse).ToList();

            var size = int.Max(joltages.Count, machine.Buttons.Count);

            var aSrc = new double[size, size];
            var rhs = new double[size, 1];

            for (var i = 0; i < joltages.Count; i++)
                rhs[i, 0] = joltages[i];

            for (var i = 0; i < joltages.Count; i++)
            {
                foreach (var (idx, b) in machine.Buttons.Index())
                {
                    if (b.Contains(i))
                        aSrc[i, idx] = 1;
                }
            }

            var A = DenseMatrix.OfArray(aSrc);
            var bVec = DenseMatrix.OfArray(rhs);
            Console.WriteLine(A);
            Console.WriteLine(bVec);
            
            var solution = A.SolveIterative(bVec, new BiCgStab());
            Console.WriteLine(solution);

            return 0;
        }

        return total;
    }
}