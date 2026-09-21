using HoneybeeHarvest.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneybeeHarvest.Controllers;

public sealed class OrdersController : Controller
{
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
    public IActionResult Create(OrderCreateViewModel model)
    {
        model.Products = Catalog.Products;
        ViewData["Submitted"] = true;
        return View(model);
    }
}