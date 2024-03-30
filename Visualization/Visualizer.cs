using EdHouse_UkolProStazisty_2024.WarehouseManagement;
using System.Drawing;

namespace EdHouse_UkolProStazisty_2024.Visualization;

/// <summary>
/// Provides a method to visualize the layout of a warehouse, displaying containers and symbols with colored representation on the console.
/// </summary>
internal static class Visualizer
{
	const char space = ' ';
	const ConsoleColor symbolColor = ConsoleColor.Yellow;
	const ConsoleColor backgroundColor = ConsoleColor.Black;
	const ConsoleColor foregroundColor = ConsoleColor.White;
	const ConsoleColor unselectedContainerColor = ConsoleColor.Red;
	const ConsoleColor selectedContainerColor = ConsoleColor.Green;

	/// <summary>
	/// Visualizes the layout of the warehouse using predefined constants
	/// </summary>
	internal static void Visualize(List<Container> containers, List<Container> adjacentContainers, List<Point> symbols, Rectangle warehouseSize)
	{
		Point defaultPoint = new Point(int.MinValue, int.MinValue);
		Console.ForegroundColor = foregroundColor;
		for (int i = 0; i < warehouseSize.Height; i++)
		{
			for(int j = 0; j < warehouseSize.Width; j++)
			{
				Container? container = containers.Find(x => x.Anchor.X == j && x.Anchor.Y == i);
				if(container is not null)
				{
					DisplayContainer(adjacentContainers, container); 
					j += container.Length - 1;

					continue;
				}
				Point symbol = symbols.FirstOrDefault(el => el.X == j && el.Y == i, defaultPoint);
				DisplaySymbolOrSpace(symbol);
			}
			Console.WriteLine();
		}
	}

	/// <summary>
	/// Displays one or more characters to the Console depending on container length
	/// </summary>
	private static void DisplayContainer(List<Container> adjacentContainers, Container container)
	{
		Console.BackgroundColor = adjacentContainers.Contains(container) ? selectedContainerColor : unselectedContainerColor;

		string containerNumber = container.Number.ToString();
		for (int k = 0; k < container.Length; k++)
		{
			Console.Write(containerNumber[k]);
		}
	}

	/// <summary>
	/// Displays a symbol to the Console
	/// </summary>
	private static void DisplaySymbolOrSpace(Point symbol)
	{
		Console.BackgroundColor = symbol.X != int.MinValue && symbol.Y != int.MinValue ? symbolColor : backgroundColor;
		Console.Write(space);
	}
}
