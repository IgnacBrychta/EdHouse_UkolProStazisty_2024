using System.Drawing;

namespace EdHouse_UkolProStazisty_2024.WarehouseManagement;

/// <summary>
/// Represents a container within a warehouse, defined by its anchor point, length, and unique number.
/// </summary>
internal sealed class Container
{
    /// <summary>
    /// Left-most coordinate of this instance
    /// </summary>
    internal Point Anchor { get; init; }
    /// <summary>
    /// Container length equivalent to the count of its digits
    /// </summary>
    internal int Length { get; init; }
    /// <summary>
    /// Container numbers
    /// </summary>
    internal int Number { get; init; }

    /// <summary>
    /// Creates a new <see cref="Container"/> instance with the specified parameters
    /// </summary>
    public Container(Point anchor, int length, int number)
    {
        Anchor = anchor;
        Length = length;
        Number = number;
    }

    public override string ToString()
    {
        return $"{Number}: {Anchor}; {Length}";
    }
}
