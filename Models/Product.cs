namespace HoneybeeHarvest.Models;

public sealed class Product
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal Price { get; init; }
}