namespace HoneybeeHarvest.Models;

public static class Catalog
{
    public static Product[] Products { get; } =
    [
        new Product
        {
            Name = "Wildflower Honey",
            Description = "A mellow fictional blend with a floral finish.",
            Price = 12.00m
        },
        new Product
        {
            Name = "Citrus Blossom",
            Description = "A bright fictional jar inspired by spring orchards.",
            Price = 14.00m
        },
        new Product
        {
            Name = "Forest Honey",
            Description = "A dark, rich fictional variety for the demo catalog.",
            Price = 16.00m
        }
    ];
}