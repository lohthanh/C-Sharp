using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;
    private MyContext _context;

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index(Chef chef)
    {
        List<Chef> AllChefs = _context.Chefs.Include(c => c.AllDishes).ToList();

        return View("Index", AllChefs);
    }

    //View chef page to add a chef
    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View();
    }

    //Action to add a chef
    [HttpPost("chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Chefs.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewChef");
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}