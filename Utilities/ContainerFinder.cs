using System.Text.RegularExpressions;
using System.Drawing;
using EdHouse_UkolProStazisty_2024.WarehouseManagement;

namespace EdHouse_UkolProStazisty_2024.Utilities;

/// <summary>
/// Provides methods to find containers and symbols within a warehouse layout, as well as identify containers adjacent to symbols.
/// </summary>
internal static class ContainerFinder
{
    private const string regexPatternContainer = @"\d{1,}";
    private static readonly Regex regexContainers = new Regex(regexPatternContainer, RegexOptions.Compiled);
    private const string regexPatternSymbol = "[^.\\d\r\n]";
    private static readonly Regex regexSymbols = new Regex(regexPatternSymbol, RegexOptions.Compiled);

    /// <summary>
    /// Finds containers within a <paramref name="warehouse"/> with Regex
    /// </summary>
    internal static List<Container> FindAllContainers(Warehouse warehouse)
    {
        List<Container> containers = new List<Container>();
        MatchCollection matchCollection = regexContainers.Matches(warehouse.Map);

        foreach (Match match in matchCollection.Cast<Match>())
        {
            int row = match.Index / warehouse.Size.Width;
            int column = match.Index - row * warehouse.Size.Width;
            containers.Add(
                new Container(
                        new Point(column, row),
                        match.Length,
                        int.Parse(match.Value)
                    )
                );
        }

        return containers;
    }

    /// <summary>
    /// Finds symbols within a <paramref name="warehouse"/> with Regex
    /// </summary>
    /// <returns>A List of coordinates of characters that are not digits, dots or newline characters</returns>
    internal static List<Point> FindAllSymbols(Warehouse warehouse)
    {
        List<Point> symbols = new List<Point>();
        MatchCollection matchCollection = regexSymbols.Matches(warehouse.Map);

        foreach (Match match in matchCollection.Cast<Match>())
        {
            int row = match.Index / warehouse.Size.Width;
            int column = match.Index - row * warehouse.Size.Width;
            symbols.Add(
                new Point(column, row)
                );
        }

        return symbols;
    }

    /// <summary>
    /// Finds all containers that are adjacent symbols
    /// </summary>
    /// <returns>A List of containers that touch a symbol, even if diagonally</returns>
    internal static List<Container> FindContainersAdjacentSymbols(List<Container> containers, List<Point> symbols)
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
                symbol.X <= containerArea.X + containerArea.Width &&
                symbol.Y >= containerArea.Y &&
                symbol.Y <= containerArea.Y + containerArea.Height
            );
            if (symbolInArea) result.Add(container);

        }
        return result;
    }
}
