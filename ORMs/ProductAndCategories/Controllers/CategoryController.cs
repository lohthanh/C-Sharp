using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAndCategories.Models;


namespace ProductAndCategories.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private MyContext _context;

    public CategoryController(ILogger<CategoryController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //To view all products and form to add product
    [HttpGet("categories")]
    public IActionResult Category()
    {
        ViewBag.AllCategories = _context.Categories.ToList(); 
        return View("Category");
    }

    //Action to add a category
    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }
        else
        {
            ViewBag.AllCategories = _context.Categories.ToList(); 
            return View("Category");
        }
    }

    //View One category
    [HttpGet("categories/{categoryId}")]
    public IActionResult ShowCategory(int categoryId)
    {
        ViewBag.AllProducts = _context.Products.ToList(); 
        Category? CategoryWithProducts = _context.Categories.Include(p => p.AssociationsFromCategory).ThenInclude(p => p.Product).FirstOrDefault(p => p.CategoryId == categoryId);
        Category? OneCategory = _context.Categories.FirstOrDefault(p => p.CategoryId == categoryId);
        if(OneCategory == null)
        {
            return RedirectToAction("Category");
        }
        return View("ShowCategory", OneCategory);
    }

    //Action to add category to product
    [HttpPost("categories/add/{categoryId}")]
    public IActionResult AddProductToCategory(int productId, int categoryId)
    {
        //Add categoryId with the chosen productId
        Association newAssociation = new Association()
        {
            ProductId = productId,
            CategoryId = categoryId
        };

        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return RedirectToAction("ShowCategory", newAssociation);
    }

     //Action to delete a product from a category
    [HttpPost("categories/{categoryId}/destroy")]
    public IActionResult Destroy(int categoryId, int productId)
    {
        Association? removeProduct = _context.Associations.FirstOrDefault(c => c.CategoryId == categoryId && c.ProductId == productId);
        // ViewBag.AllCategory = _context.Categories.ToList();
        if (removeProduct != null)
        {
            _context.Associations.Remove(removeProduct);
            _context.SaveChanges();
        }
        return RedirectToAction("ShowCategory", new { categoryId });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}