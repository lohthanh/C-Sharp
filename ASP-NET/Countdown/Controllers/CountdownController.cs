using Microsoft.AspNetCore.Mvc;
namespace Countdown.Controllers;

public class CountdownController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View("index");
    }

}