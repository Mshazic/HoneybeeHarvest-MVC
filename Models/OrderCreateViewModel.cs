namespace HoneybeeHarvest.Models;

public sealed class OrderCreateViewModel
{
    public OrderInputModel Input { get; set; } = new();
    public Product[] Products { get; set; } = [];
}