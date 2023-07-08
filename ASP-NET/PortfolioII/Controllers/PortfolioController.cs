using Microsoft.AspNetCore.Mvc;
namespace Portfolio.Controllers;

public class PortfolioController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        //only avail in the index. only lives in the one action it was declared in
        // ViewBag.Name = "Leliana";
        // ViewBag.Number = 4;
        // ViewBag.SweetsList = new List<string>() {"Ice Cream", "Cupcakes", "Pecan Tarts"};
        return View("index");
    }

    [HttpGet("projects")]
    public ViewResult Projects()
    {
        return View("projects");
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View("contact");
    }


}