using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;


namespace FormSubmission.Controllers;

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

    public IActionResult Success(User user)
    {
        DateTime dob = (DateTime)user.DateOfBirth;
        ViewBag.Date = dob.ToString("dddd, dd MMMM yyyy");
        return View("Success", user);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost("Create")]
    public IActionResult Create(User user)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Success", user);
        } else {
            return View("Index");
        };
    }


}
