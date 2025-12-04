using AdventOfCodeSupport;

namespace AoC_2025._2025;

public class Day04 : AdventBase
{
    protected override object InternalPart1()
    {
        var width = Input.Lines[0].Length;
        var height = Input.Lines.Length;

        var count = 0;
        for (int i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if (Input.Lines[j][i] == '.')
                    continue;

                var neighborCount = 0;

                if (j - 1 >= 0 && j - 1 < height && Input.Lines[j - 1][i] == '@')
                    neighborCount++;
                if (j + 1 >= 0 && j + 1 < height && Input.Lines[j + 1][i] == '@')
                    neighborCount++;
                if (i - 1 >= 0 && i - 1 < width && Input.Lines[j][i - 1] == '@')
                    neighborCount++;
                if (i + 1 >= 0 && i + 1 < width && Input.Lines[j][i + 1] == '@')
                    neighborCount++;
                if (j - 1 >= 0 && j - 1 < height && i - 1 >= 0 && i - 1 < width && Input.Lines[j - 1][i - 1] == '@')
                    neighborCount++;
                if (j - 1 >= 0 && j - 1 < height && i + 1 >= 0 && i + 1 < width && Input.Lines[j - 1][i + 1] == '@')
                    neighborCount++;
                if (j + 1 >= 0 && j + 1 < height && i - 1 >= 0 && i - 1 < width && Input.Lines[j + 1][i - 1] == '@')
                    neighborCount++;
                if (j + 1 >= 0 && j + 1 < height && i + 1 >= 0 && i + 1 < width && Input.Lines[j + 1][i + 1] == '@')
                    neighborCount++;

                if (neighborCount < 4)
                    count++;

                if (i == 1 && j == 1)
                    Console.WriteLine(neighborCount);
            }
        }

        return count;
    }

    protected override object InternalPart2()
    {
        var width = Input.Lines[0].Length;
        var height = Input.Lines.Length;

        var input = Input.Lines.Select(l => l.ToCharArray()).ToArray();

        var count = 0;
        var removed = Remove(input, width, height);
        while (removed != 0)
        {
            count += removed;
            removed = Remove(input, width, height);
        }

        return count;
    }

    private int Remove(char[][] input, int width, int height)
    {
        var count = 0;
        for (int i = 0; i < width; i++)
        {
            for (var j = 0; j < height; j++)
            {
                if (input[j][i] == '.')
                    continue;

                var neighborCount = 0;

                if (j - 1 >= 0 && j - 1 < height && input[j - 1][i] == '@')
                    neighborCount++;

                if (j + 1 >= 0 && j + 1 < height && input[j + 1][i] == '@')
                    neighborCount++;
                if (i - 1 >= 0 && i - 1 < width && input[j][i - 1] == '@')
                    neighborCount++;

                if (i + 1 >= 0 && i + 1 < width && input[j][i + 1] == '@')
                    neighborCount++;

                if (j - 1 >= 0 && j - 1 < height && i - 1 >= 0 && i - 1 < width && input[j - 1][i - 1] == '@')
                    neighborCount++;

                if (j - 1 >= 0 && j - 1 < height && i + 1 >= 0 && i + 1 < width && input[j - 1][i + 1] == '@')
                    neighborCount++;

                if (j + 1 >= 0 && j + 1 < height && i - 1 >= 0 && i - 1 < width && input[j + 1][i - 1] == '@')
                    neighborCount++;

                if (j + 1 >= 0 && j + 1 < height && i + 1 >= 0 && i + 1 < width && input[j + 1][i + 1] == '@')
                    neighborCount++;

                if (neighborCount < 4)
                {
                    input[j][i] = '.';
                    count++; 
                }
            }
        }

        return count;
    }
}