using HoneybeeHarvest.Data;
using HoneybeeHarvest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneybeeHarvest.Controllers;

public sealed class OrdersController(HoneybeeContext context) : Controller
{
    private readonly HoneybeeContext _context = context;

    [HttpGet]
    public IActionResult Create(string? product)
    {
        return View(new OrderCreateViewModel
        {
            Input = new OrderInputModel
            {
                ProductName = product ?? string.Empty
            },
            Products = Catalog.Products
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OrderCreateViewModel model)
    {
        model.Products = Catalog.Products;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var order = new Order
        {
            CustomerName = model.Input.CustomerName,
            Email = model.Input.Email,
            ProductName = model.Input.ProductName,
            Quantity = model.Input.Quantity,
            CreatedAtUtc = DateTime.UtcNow
        };

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var orders = await _context.Orders
            .OrderByDescending(order => order.CreatedAtUtc)
            .ToListAsync();

        return View(orders);
    }
}