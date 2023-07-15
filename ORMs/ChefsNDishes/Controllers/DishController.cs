using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("dishes")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Creator).ToList();
        return View("Index", AllDishes);
    }

    //View chef page to add a dish
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        List<Chef> AllChefs = _context.Chefs.ToList();
        ViewBag.ChefName = AllChefs;
        return View();
    }



    //Action to add a dish
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)

        {
            _logger.LogInformation("Passed validation");
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            _logger.LogInformation("Failed validation");
            List<Chef> AllChefs = _context.Chefs.ToList();
            ViewBag.ChefName = AllChefs;
            return View("NewDish");
        }
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}