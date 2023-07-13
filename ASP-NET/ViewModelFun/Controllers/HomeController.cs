using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {   
        string Quote = "“To know sorrow is not terrifying. What is terrifying is to know you can’t go back to happiness you could have.” — Matsumoto Rangiku (Bleach)";
        return View("Index",Quote);
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

    [HttpGet("numbers")]
    public IActionResult Numbers()
    {
        List<int> numbers = new List<int>() {2,3,4,15,90,34,56};
        return View("Numbers", numbers);
    }

    [HttpGet("user")]
    public IActionResult User()
    {
        User newUser = new User()
        {
            FirstName = "Leliana",
            LastName = "Nightingale"
        };
        return View("user", newUser);
    }

    [HttpGet("users")]
    public IActionResult Users()
    {
        List<User> AllNames = new List<User>()
        {
            new User() {FirstName = "Dorian", LastName = "Pavus"},
            new User() {FirstName = "Cassandra", LastName = "Pentaghast"},
            new User() {FirstName = "Varric", LastName = "Tethras"},
            new User() {FirstName = "Josephine", LastName = "Montilyet"}
        };

        return View("users", AllNames);
    }
    
}
