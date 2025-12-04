using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day04 : AdventBase
{
    protected override object InternalPart1()
    {
        var width = Input.Lines[0].Length;
        var height = Input.Lines.Length;

        var grid = Input.ToGrid();

        var count = 0;
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if (Input.Lines[j][i] == '.')
                    continue;

                var neighborCount = grid.Neighbors8(i, j).Count(n => n == '@');

                if (neighborCount < 4)
                    count++;
            }
        }

        return count;
    }

    protected override object InternalPart2()
    {
        var width = Input.Lines[0].Length;
        var height = Input.Lines.Length;

        var grid = Input.ToGrid();

        var count = 0;
        var removed = Remove(grid, width, height);
        while (removed != 0)
        {
            count += removed;
            removed = Remove(grid, width, height);
        }

        return count;
    }

    private int Remove(Grid input, int width, int height)
    {
        var count = 0;
        for (var i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if (input[i, j] == '.')
                    continue;

                var neighborCount = input.Neighbors8(i, j).Count(n => n == '@');
                if (neighborCount < 4)
                {
                    input[i, j] = '.';
                    count++;
                }
            }
        }

        return count;
    }
}