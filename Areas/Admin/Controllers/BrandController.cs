using Microsoft.AspNetCore.Mvc;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/Brand")]
public class BrandController : Controller
{
    private readonly ICrudBrand _brand;
    public BrandController(ICrudBrand brand)
    {
        _brand = brand;
    }
    [HttpGet]
    [Route("GetBrand")]
    public IActionResult GetBrand()
    {
        var getBrand = _brand.GetAllBrand();
        return Ok(getBrand);
    }
    [HttpGet]
    [Route("ShowListBrand")]
    public IActionResult ShowListBrand()
    {
        return View();
    }

    [HttpGet]
    [Route("ShowAddBrand")]
    public IActionResult ShowAddBrand()
    {
        return View(new Brand());
    }

    [HttpPost]
    [Route("AddBrand")]
    public IActionResult AddBrand([FromForm] Brand brand)
    {
        if (!ModelState.IsValid)
        {
            return View("ShowAddBrand", brand);
        }
        bool isSuccess = _brand.AddBrand(brand);

        if (isSuccess)
        {
            return RedirectToAction("ShowListBrand");
        }
        else
        {
            TempData["ErrorMessage"] = "error while adding category!";
            return View("ShowAddBrand", brand);
        }
    }

    [HttpPost]
    [Route("DeleteBrand")]
    public IActionResult DeleteBrand(int id)
    {
        var isDeleted = _brand.DeleteBrand(id);

        if (isDeleted)
        {
            return Json(new { success = true, message = "delete successfully" });
        }
        return Json(new { success = false, message = "Delete failed!" });
    }

    [HttpGet]
    [Route("ShowUpdateBrand")]
    public IActionResult ShowUpdateBrand(int id)
    {
        var getBrandId = _brand.GetGroupById(id);
        if(getBrandId == null)
        {
            TempData["ErrorMessage"] = "Category not found!";
            return RedirectToAction("ShowListBrand");
        }
        return View(getBrandId);
    }

    [HttpPost]
    [Route("UpdateBrand")]
    public IActionResult UpdateBrand([FromForm] Brand brand)
    {
        if(!ModelState.IsValid) 
        {
            TempData["ErrorMessage"] = "Invalid data!";
            return View("ShowUpdateBrand", brand);
        }

        var isSuccess = _brand.UpdateBrand(brand);

        if(isSuccess)
        {
            return RedirectToAction("ShowListBrand");
        }
        else
        {
            TempData["ErrorMessage"] = "Error while updating Brand!";
            return View("ShowUpdateBrand",brand);
        }
    }
}
