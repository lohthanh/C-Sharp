using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAndCategories.Models;


namespace ProductAndCategories.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private MyContext _context;

    public ProductController(ILogger<ProductController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    //To view all products and form to add product
    [HttpGet("")]
    public IActionResult Product()
    {
        ViewBag.AllProducts = _context.Products.ToList();
        return View("Product");
    }

    //Action to add a product
    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Product");
        }
        else
        {
            ViewBag.AllProducts = _context.Products.ToList();
            return View("Product");
        }
    }

    //View one product page
    [HttpGet("products/{productId}")]
    public IActionResult ShowProduct(int productId)
    {
        ViewBag.AllCategory = _context.Categories.ToList();
        Product? ProductWithCategories = _context.Products.Include(p => p.AssociationsFromProducts).ThenInclude(p => p.Category).FirstOrDefault(p => p.ProductId == productId);
        Product? OneProduct = _context.Products.FirstOrDefault(p => p.ProductId == productId);
        if (OneProduct == null)
        {
            return RedirectToAction("Product");
        }
        return View("ShowProduct", OneProduct);
    }

    //Action to add category to product
    [HttpPost("products/add/{productId}")]
    public IActionResult AddCategoryToProduct(int productId, int categoryId)
    {
        //Add productId with the chosen categoryId
        Association newAssociation = new Association()
        {
            ProductId = productId,
            CategoryId = categoryId
        };
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return RedirectToAction("ShowProduct", newAssociation);
    }

    //Action to delete category from a product
    [HttpPost("products/{productId}/destroy")]
    public IActionResult Destroy(int categoryId, int productId)
    {
        Association? removeCategory = _context.Associations.FirstOrDefault(c => c.CategoryId == categoryId && c.ProductId == productId);
        // ViewBag.AllCategory = _context.Categories.ToList();
        if (removeCategory != null)
        {
            _context.Associations.Remove(removeCategory);
            _context.SaveChanges();

        }
        return RedirectToAction("ShowProduct", new { productId });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}