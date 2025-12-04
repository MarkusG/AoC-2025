using AdventOfCodeSupport;

namespace AoC_2025;

public class Grid
{
    private readonly char[][] _grid;

    public Grid(InputBlock block)
    {
        _grid = block.Lines.Select(l => l.ToCharArray()).ToArray();
        Width = block.Lines[0].Length;
        Height = block.Lines.Length;
    }

    public int Width { get; }

    public int Height { get; }

    public char this[int x, int y]
    {
        get => _grid[y][x];
        set => _grid[y][x] = value;
    }

    public IEnumerable<char> Enumerate()
    {
        for (var i = 0; i < Width; i++)
        {
            for (var j = 0; j < Height; j++)
                yield return this[i, j];
        }
    }

    public IEnumerable<char> Neighbors4(int x, int y)
    {
        if (x - 1 >= 0 && x - 1 < Width)
            yield return this[x - 1, y];
        if (x + 1 >= 0 && x + 1 < Width)
            yield return this[x + 1, y];
        if (y - 1 >= 0 && y - 1 < Height)
            yield return this[x, y - 1];
        if (y + 1 >= 0 && y + 1 < Height)
            yield return this[x, y + 1];
    }

    public IEnumerable<char> Neighbors8(int x, int y)
    {
        if (x - 1 >= 0 && x - 1 < Width)
        {
            if (y - 1 >= 0 && y - 1 < Height)
                yield return this[x - 1, y - 1];
            if (y + 1 >= 0 && y + 1 < Height)
                yield return this[x - 1, y + 1];

            yield return this[x - 1, y];
        }

        if (x + 1 >= 0 && x + 1 < Width)
        {
            if (y - 1 >= 0 && y - 1 < Height)
                yield return this[x + 1, y - 1];
            if (y + 1 >= 0 && y + 1 < Height)
                yield return this[x + 1, y + 1];

            yield return this[x + 1, y];
        }

        if (y - 1 >= 0 && y - 1 < Height)
            yield return this[x, y - 1];
        if (y + 1 >= 0 && y + 1 < Height)
            yield return this[x, y + 1];
    }
}