using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeddingPlanner.Controllers;


public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext DB;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        DB = context;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //View of home screen and login 
    [HttpGet("")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetInt32("UUID") != null)
        {
            return RedirectToAction("Index");
        }
        return View("Index");
    }

    //Action to create a user
    [HttpPost("CreateUser")]
    public IActionResult CreateUser(User newUser)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        User? userInDb = DB.Users.FirstOrDefault(u => u.Email == newUser.Email);
        if (userInDb != null)
        {
            ModelState.AddModelError("Email", "Email already exists!");
            return View("Index");
        }
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
        DB.Add(newUser);
        DB.SaveChanges();
        HttpContext.Session.SetString("UserName", newUser.FirstName);
        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        return RedirectToAction("Wedding", "Wedding");
    }


    [HttpPost("login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }

        User? userInDb = DB.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
        if (userInDb == null)
        {
            ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
            return View("Index");
        }
        PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
        var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
        if (result == 0)
        {
            ModelState.AddModelError("LoginPassword", "Invalid Email/Password");
            return View("Index");
        }
        HttpContext.Session.SetInt32("UUID", userInDb.UserId);
        HttpContext.Session.SetString("UserName", userInDb.FirstName);
        return RedirectToAction("Wedding", "Wedding");
    }


    //Action to clear session
    [SessionCheck]
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

}