using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

[SessionCheck]
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext DB;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        DB = context;
    }

    //To view all
    [HttpGet("weddings")]
    public IActionResult Wedding()
    {
        List<Wedding> allWedding = DB.Weddings.Include(w => w.AssociationsFromWedding).ToList();

        return View(allWedding);
    }

    //View add wedding form

    [HttpGet("weddings/new")]
    public IActionResult ViewNew()
    {
        return View();
    }

    //Action to add a wedding
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (!ModelState.IsValid)
        {
            return View("ViewNew");
        }
        newWedding.UserId = (int)HttpContext.Session.GetInt32("UUID");
        DB.Weddings.Add(newWedding);
        DB.SaveChanges();
        return RedirectToAction("Wedding", newWedding);
    }


    //View one
    [HttpGet("weddings/{id}")]
    public IActionResult ShowOne(int id)
    {
        Wedding? WeddingWithPeople = DB.Weddings.Include(x => x.AssociationsFromWedding).ThenInclude(x => x.User).FirstOrDefault(x => x.WeddingId == id);
        Wedding? OneWedding = DB.Weddings.FirstOrDefault(w => w.WeddingId == id);
        if (OneWedding == null)
        {
            return RedirectToAction("Wedding");
        }
        return View("ShowOne", OneWedding);
    }

    //Delete a wedding
    [HttpPost("weddings/{id}/delete")]
    public IActionResult DeleteWedding(int id)
    {
        Wedding? removeWedding = DB.Weddings.FirstOrDefault(w => w.WeddingId == id);
        if (removeWedding == null)
        {
            return View("Wedding");
        }
        DB.Weddings.Remove(removeWedding);
        DB.SaveChanges();
        return RedirectToAction("Wedding");
    }

    //Form to add to Association table
    [HttpPost("weddings/add")]
    public IActionResult AddUserToWedding(int weddingId)
    {
        int userId = (int)HttpContext.Session.GetInt32("UUID");
        Association? existing = DB.Associations.FirstOrDefault(w => w.UserId == userId && w.WeddingId == weddingId);
        if (existing != null)
        {
            DB.Associations.Remove(existing);
        }
        else
        {
            Association newAssociation = new Association()
            {
                WeddingId = weddingId,
                UserId = userId
            };
            DB.Associations.Add(newAssociation);
        }
        DB.SaveChanges();
        return RedirectToAction("Wedding");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}