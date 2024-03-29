using System.Drawing;


namespace EdHouse_UkolProStazisty_2024.Models;

internal sealed class Container
{
	internal Point Anchor { get; init; }
	internal int Length { get; init; }
	internal int Number { get; init; }

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
