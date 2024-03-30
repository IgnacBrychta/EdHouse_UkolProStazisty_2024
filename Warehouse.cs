using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdHouse_UkolProStazisty_2024;

internal class Warehouse
{
	private string _map;
    public string Map { get => _map; }
    private Rectangle _size;
	public Rectangle Size { get => _size; }
	internal Warehouse(string warehouseMap)
	{
		_map = warehouseMap;
		_size = GetWarehouseSize(warehouseMap);
	}
	private static Rectangle GetWarehouseSize(string warehouseMap)
	{
		// Environment.NewLine = "\r\n" -> "\r\n".Length = 2 -> +2
		int width = warehouseMap.IndexOf(Environment.NewLine) + 2;
		int height = warehouseMap.Length / width;
		return new Rectangle(0, 0, width, height);
	}
}
