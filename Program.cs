using EdHouse_UkolProStazisty_2024.Utilities;
using EdHouse_UkolProStazisty_2024.Visualization;
using EdHouse_UkolProStazisty_2024.WarehouseManagement;
using System.Diagnostics;
using System.Drawing;

namespace EdHouse_UkolProStazisty_2024;
internal class Program
{
	static void Main(string[] args)
	{
		string input;
#if DEBUG
		input = File.ReadAllText("../../../input data/warehouse map large.txt");
#else
		input = Console.In.ReadToEnd();
#endif
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Warehouse warehouse = new Warehouse(input);
		List<Container> containers = ContainerFinder.FindAllContainers(warehouse);
		List<Point> symbols = ContainerFinder.FindAllSymbols(warehouse);
		List<Container> containersNearSymbols = ContainerFinder.FindContainersAdjacentSymbols(containers, symbols);
        int sumOfContainerNumbers = containersNearSymbols.Select(c => c.Number).Sum();
		stopwatch.Stop();

		Console.WriteLine(
#if DEBUG
			"Sum of containers adjacent to symbols: " + 
#endif
			sumOfContainerNumbers.ToString());

#if DEBUG
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed.TotalMilliseconds} ms");
		Visualizer.Visualize(containers, containersNearSymbols, symbols, warehouse.Size);
		Console.ReadKey();
#endif
	}
}
