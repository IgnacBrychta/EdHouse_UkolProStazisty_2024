using EdHouse_UkolProStazisty_2024.Models;
using System.Drawing;

internal static class Visualizer
{
	const char space = ' ';
	const ConsoleColor symbolColor = ConsoleColor.Yellow;
	const ConsoleColor backgroundColor = ConsoleColor.Black;
	const ConsoleColor foregroundColor = ConsoleColor.White;
	const ConsoleColor unselectedContainerColor = ConsoleColor.Red;
	const ConsoleColor selectedContainerColor = ConsoleColor.Green;
	internal static void Visualize(List<Container> containers, List<Container> selectedContainers, List<Point> symbols, Rectangle warehouseSize)
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
					DisplayContainer(selectedContainers, container); 
					j += container.Length - 1;

					continue;
				}
				Point symbol = symbols.FirstOrDefault(el => el.X == j && el.Y == i, defaultPoint);
				DisplaySymbolOrSpace(symbol);
			}
			Console.WriteLine();
		}
	}

	private static void DisplayContainer(List<Container> selectedContainers, Container container)
	{
		Console.BackgroundColor = selectedContainers.Contains(container) ? selectedContainerColor : unselectedContainerColor;

		string containerNumber = container.Number.ToString();
		for (int k = 0; k < container.Length; k++)
		{
			Console.Write(containerNumber[k]);
		}
	}

	private static void DisplaySymbolOrSpace(Point symbol)
	{
		Console.BackgroundColor = symbol.X != int.MinValue && symbol.Y != int.MinValue ? symbolColor : backgroundColor;
		Console.Write(space);
	}
}
