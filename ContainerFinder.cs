using EdHouse_UkolProStazisty_2024.Models;
using System.Text.RegularExpressions;
using System.Drawing;

namespace EdHouse_UkolProStazisty_2024;

internal static class ContainerFinder
{
	private const string regexPatternContainer = @"\d{1,}";
	private static readonly Regex regexContainers = new Regex(regexPatternContainer, RegexOptions.Compiled);
	private const string regexPatternSymbol = "[^.\\d\r\n]";
	private static readonly Regex regexSymbols = new Regex(regexPatternSymbol, RegexOptions.Compiled);

	internal static List<Container> FindAllContainers(string warehouseMap)
	{
		List<Container> containers = new List<Container>();
		MatchCollection matchCollection = regexContainers.Matches(warehouseMap);
		Rectangle warehouseSize = GetWarehouseSize(warehouseMap);

		foreach (Match match in matchCollection.Cast<Match>())
		{
			int row = match.Index / warehouseSize.Width;

			containers.Add(
				new Container(
						new Point(
							match.Index - row * warehouseSize.Width,
							row
							),
						match.Length,
						int.Parse(match.Value)
					)
				);
        }

		return containers;
	}

	internal static List<Point> FindAllSymbols(string warehouseMap)
	{
		List<Point> symbols = new List<Point>();
		MatchCollection matchCollection = regexSymbols.Matches(warehouseMap);
		Rectangle warehouseSize = GetWarehouseSize(warehouseMap);

		foreach (Match match in matchCollection.Cast<Match>())
		{
			int row = match.Index / warehouseSize.Width;

			symbols.Add(
				new Point(
						match.Index - row * warehouseSize.Width,
						row
					)
				);
		}

		return symbols;
	} 

	internal static List<Container> FindContainersNextToSymbols(List<Container> containers, List<Point> symbols)
	{
		List<Container> result = new List<Container>();
		foreach (Container container in containers)
		{
			Rectangle containerArea = new Rectangle(
				container.Anchor.X - 1,
				container.Anchor.Y - 1,
				container.Length + 1,
				2
				);
			bool symbolInArea = symbols.Any(symbol => 
				symbol.X >= containerArea.X &&
				symbol.X <= (containerArea.X + containerArea.Width) && 
				symbol.Y >= containerArea.Y &&
				symbol.Y <= (containerArea.Y + containerArea.Height)
			);
			if (symbolInArea) result.Add(container);

		}
		return result;
	}

	internal static Rectangle GetWarehouseSize(string warehouseMap)
	{
		// Environment.NewLine = "\r\n" -> .Length -> +2
		int width = warehouseMap.IndexOf(Environment.NewLine) + 2;
		int height = warehouseMap.Length / width;
		return new Rectangle(0, 0, width, height);
	}
}
