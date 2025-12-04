using AdventOfCodeSupport;

namespace AoC_2025;

public static class Extensions
{
    /// <summary>
    /// Indexed by y from the top first, then x from the left
    /// </summary>
    public static Grid ToGrid(this InputBlock block) => new(block);
}