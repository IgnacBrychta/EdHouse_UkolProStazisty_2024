using System.Drawing;

namespace EdHouse_UkolProStazisty_2024.WarehouseManagement;

/// <summary>
/// Represents a warehouse layout
/// </summary>
internal class Warehouse
{
    private string _map;
    /// <summary>
    /// Gets the string map of the warehouse
    /// </summary>
    public string Map { get => _map; }
    private Rectangle _size;
    /// <summary>
    /// Gets the calculated size of the warehouse
    /// </summary>
    public Rectangle Size { get => _size; }

    /// <summary>
    /// Creates a new <see cref="Warehouse"/> instance and calculates its <see cref="Size"/>
    /// </summary>
    internal Warehouse(string warehouseMap)
    {
        _map = warehouseMap;
        _size = GetWarehouseSize(warehouseMap);
    }

    /// <summary>
    /// Calculates the width and height of the warehouse without splitting it into an array
    /// </summary>
    private static Rectangle GetWarehouseSize(string warehouseMap)
    {
        // Environment.NewLine = "\r\n" -> "\r\n".Length = 2 -> +2
        int width = warehouseMap.IndexOf(Environment.NewLine) + 2;
        int height = warehouseMap.Length / width;
        return new Rectangle(0, 0, width, height);
    }
}
