using HoneybeeHarvest.Models;
using Microsoft.EntityFrameworkCore;

namespace HoneybeeHarvest.Data;

public sealed class HoneybeeContext(DbContextOptions<HoneybeeContext> options)
    : DbContext(options)
{
    public DbSet<Order> Orders { get; set; } = null!;
}