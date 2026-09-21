using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HoneybeeHarvest.Models;

namespace HoneybeeHarvest.Controllers;

public sealed class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Catalog.Products);
    }
}
