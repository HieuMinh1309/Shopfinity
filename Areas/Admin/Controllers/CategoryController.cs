using Microsoft.AspNetCore.Mvc;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Areas.Admin.Services;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Category")]
public class CategoryController : Controller
{
    private readonly ICrudCategory _category;

    public CategoryController(ICrudCategory category)
    {
        _category = category;
    }
    
    [HttpGet]
    [Route("GetCategories")]

    public IActionResult GetCategories()
    {
        var categories = _category.getAllCategories();
        return Ok(categories);
    }
    [HttpGet]
    [Route("ShowListCategories")]
    public IActionResult ShowListCategories()
    {
        return View();
    }


    [HttpGet]
    [Route("ShowAddCategory")]
    public IActionResult ShowAddCategory()
    {
        return View(new ProductCategory()); 
    }

    [HttpPost]
    [Route("AddCategory")]

    public IActionResult AddCategory([FromForm] ProductCategory category)
    {
        
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Invalid data!";
            return View("ShowAddCategory", category);
        }

        bool isSuccess = _category.AddCategory(category);

        if (isSuccess)
        {           
            return RedirectToAction("ShowListCategories");
        }
        else
        {
            TempData["ErrorMessage"] = "error while adding category!";
            return View("ShowAddCategory", category);
        }
    }

    [HttpPost]
    [Route("DeleteCategory")]
    public IActionResult DeleteCategory(int id)
    {
        bool isDeleted = _category.DeleteCategory(id);

        if (isDeleted)
        {
            return Json(new { success = true, message = "Delete directory successfully!" });
        }
        return Json(new { success = false, message = "Delete failed! Category not found or an error occurred." });
    }

    [HttpPost]
    [Route("UpdateCategory")]
    public IActionResult UpdateCategory([FromForm] ProductCategory category)
    {
        Console.WriteLine(">>> UpdateCategory method called <<<");
        Console.WriteLine($"Category ID received: {category.Id}");
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            Console.WriteLine($"ModelState Errors: {string.Join(", ", errors)}");

            TempData["ErrorMessage"] = "Invalid data!";
            return View("ShowUpdateCategory", category);
        }
        
        bool isUpdated = _category.UpdateCategory(category);

        if (isUpdated)
        {
            return RedirectToAction("ShowListCategories");
        }
        else
        {
            TempData["ErrorMessage"] = "Error while updating category!";
            return View("ShowUpdateCategory");
        }
    }



    [HttpGet]
    [Route("ShowUpdateCategory")]
    public IActionResult ShowUpdateCategory(int id)
    {
        var category = _category.GetCategoryById(id);
        if (category == null)
        {
            TempData["ErrorMessage"] = "Category not found!";
            return RedirectToAction("ShowListCategories");
        }
        return View(category);
    }



}
