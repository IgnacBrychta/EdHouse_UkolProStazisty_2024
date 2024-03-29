#define DEV
//#undef DEV
using EdHouse_UkolProStazisty_2024.Models;
using System.Drawing;

namespace EdHouse_UkolProStazisty_2024;
internal class Program
{
	static void Main(string[] args)
	{
		string input;
#if DEV
		input = File.ReadAllText("../../../input data/mapka.txt");
#else
		input = Console.In.ReadToEnd();
#endif

#warning break down ContainerFinder
		List<Container> containers = ContainerFinder.FindAllContainers(input);
		List<Point> symbols = ContainerFinder.FindAllSymbols(input);
		List<Container> containersNearSymbols = ContainerFinder.FindContainersNextToSymbols(containers, symbols);
        int sumOfContainerNumbers = containersNearSymbols.Select(c => c.Number).Sum();
		Console.WriteLine(sumOfContainerNumbers.ToString());

		Rectangle warehouseSize = ContainerFinder.GetWarehouseSize(input);
		Visualizer.Visualize(containers, containersNearSymbols, symbols, warehouseSize);
		Console.ReadKey();
	}
}

// specialni znaky
// *=/%#&$-@+
// regex
// (?<!\d)\d{5}(?!\d)
// některé kontejnery existují dvakrát se stejným číslem