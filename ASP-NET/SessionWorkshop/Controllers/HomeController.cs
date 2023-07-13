using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

    [HttpPost("process")]
    public IActionResult Process(string Name)
    {
        if(!ModelState.IsValid)
        {
            return View("Index");
        }
        HttpContext.Session.SetString("Name", Name);
        HttpContext.Session.SetInt32("StartValue", 22);
        return View("dashboard");
    }

    [HttpPost("clear")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

//view dashboard
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetString("Name") == null) 
        {
            return RedirectToAction("Index");
        }
        return View("Dashboard");
    }

    [HttpPost("math")]
    public IActionResult Math(string functionality)
    {
        int? IntVariable = HttpContext.Session.GetInt32("StartValue");

        if(functionality == "plusOne")
        {
            IntVariable += 1;
        } else if (functionality == "minusOne") {
            IntVariable -= 1;
        } else if (functionality == "multiply") {
            IntVariable *= 2;
        } else if(functionality == "randomNum") {
            Random rand = new Random();
            int randNum = rand.Next(1, 11);
            IntVariable += randNum;
        }
        HttpContext.Session.SetInt32("StartValue", (int)IntVariable);
        return RedirectToAction("dashboard");
    }
}
