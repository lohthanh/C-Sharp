using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;


namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    //View All
    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View("Index", AllDishes);
    }

    //View Create Page
    [HttpGet("dishes/new")]
    public IActionResult New()
    {
        return View();
    }

    //Action to create
    [HttpPost("dishes/create")]
    public IActionResult Create(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index", newDish);
        }
        else
        {
            return View("New");
        }
    }

    //View One
    [HttpGet("dishes/{DishId}")]
    public IActionResult Show(int DishId)
    {
        Dish? OneDish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        if (OneDish == null)
        {
            return RedirectToAction("Index");
        }
        return View("Show", OneDish);
    }

    //View Edit page
    [HttpGet("dishes/{DishId}/edit")]
    public IActionResult Edit(int DishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);
        // Tip: it would be good to add a check here to ensure what you are grabbing will not return a null item
        if (DishToEdit == null)
        {
            return RedirectToAction("Index");
        }
        return View("Edit", DishToEdit);
    }

    //Action to update
    [HttpPost("dishes/{DishId}/update")]
    public IActionResult Update(Dish newDish, int DishId)
    {
        // 2. Find the old version of the instance in your database
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);
        if (OldDish == null)
        {
            return RedirectToAction("Show");
        }
        // 3. Verify that the new instance passes validations
        if (ModelState.IsValid)
        {
            // 4. Overwrite the old version with the new version
            // Yes, this has to be done one attribute at a time
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Calories = newDish.Calories;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Description = newDish.Description;
            // You updated it, so update the UpdatedAt field!
            OldDish.UpdatedAt = DateTime.Now;
            // 5. Save your changes
            _context.SaveChanges();
            // 6. Redirect to an appropriate page
            return RedirectToAction("Show", newDish);
        }
        else
        {
            // 3.5. If it does not pass validations, show error messages
            // Be sure to pass the form back in so you don't lose your changes
            // It should be the old version so we can keep the ID
            return View("Edit", OldDish);
        }
    }

    //Destroy
    [HttpPost("dishes/{DishId}/destroy")]
    public IActionResult Destroy(int DishId)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == DishId);
        // Once again, it could be a good idea to verify the monster exists before deleting
        if (DishToDelete == null)
        {
            return RedirectToAction("Show");
        }
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

