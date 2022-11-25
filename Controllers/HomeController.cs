using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using app_appinsightsdemo.Models;
using app_appinsightsdemo.Data;
using Microsoft.EntityFrameworkCore;

namespace app_appinsightsdemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DemoContext context;

    public HomeController(ILogger<HomeController> logger, DemoContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await context.Quotes.ToListAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
