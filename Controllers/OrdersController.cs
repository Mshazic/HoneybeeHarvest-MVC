using HoneybeeHarvest.Models;
using Microsoft.AspNetCore.Mvc;
using HoneybeeHarvest.Data;
using HoneybeeHarvest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HoneybeeHarvest.Controllers;

public sealed class OrdersController : Controller
{
    private readonly HoneybeeContext _context;

    public OrdersController(HoneybeeContext context)
    {
        _context = context;
    }

       [HttpGet]
    public async Task<IActionResult> Index()
    {
        var orders = await _context.Orders
            .OrderByDescending(order => order.CreatedAtUtc)
            .ToListAsync();

        return View(orders);
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
}