using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers;

public class DojoSurveyController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
     public IActionResult Process(string Name, string Location, string Language, string Comment)
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Location: {Location}");
        Console.WriteLine($"Language: {Language}");
        Console.WriteLine($"Comment: {Comment}");
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        return View("Results");
        // return View("Index");
    }

    [HttpGet("results")]
    public ViewResult Results()
    {
        return View("results");
    }

}