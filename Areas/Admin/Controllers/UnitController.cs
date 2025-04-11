using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using SSE_Project.Areas.Admin.Interfaces;
using SSE_Project.Models;

namespace SSE_Project.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/Unit")]
public class UnitController : Controller
{
    private readonly ICrudUnit _unit;
    public UnitController(ICrudUnit unit)
    {
        _unit = unit;
    }
    [HttpGet]
    [Route("GetUnit")]
    public IActionResult GetUnit()
    {
        var getUnit = _unit.getAllUnit();
        return Ok(getUnit);
    }
    [HttpGet]
    [Route("ShowListUnit")]
    public IActionResult ShowListUnit() 
    {
        return View();
    }

    [HttpPost]
    [Route("DeleteUnit")]
    public IActionResult DeleteUnit(int id)
    {
        var isDeleted = _unit.DeleteUnit(id);

        if (isDeleted)
        {
            return Json(new { success = true, message = "delete successfully" });
        }
        return Json(new { success = false, message = "Delete failed!" });
    }

    [HttpGet]
    [Route("ShowAddUnit")]
    public IActionResult ShowAddUnit()
    {
        return View(new Unit());
    }

    [HttpPost]
    [Route("AddUnit")]
    public IActionResult AddUnit([FromForm] Unit unit)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Invalid data!";
            return View("ShowAddUnit", unit);
        }
        bool isSuccess = _unit.AddUnit(unit);
        if (isSuccess)
        {
            return RedirectToAction("ShowListUnit");
        }
        else
        {
            TempData["ErrorMessage"] = "error while adding Unit!";
            return View("ShowAddUnit", unit);
        }
    }
    [HttpGet]
    [Route("ShowUpdateUnit")]
    public IActionResult ShowUpdateUnit(int id)
    {
        var unit = _unit.GetGroupByUnit(id);
        if (unit == null)
        {
            TempData["ErrorMessage"] = "unit not found!";
            return RedirectToAction("ShowListUnit");
        }
        return View(unit);
    }
    [HttpPost]
    [Route("UpdateUnit")]
    public IActionResult UpdateUnit([FromForm] Unit unit)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorUpdateUnit"] = "Invalid data unit!";
            return View("ShowUpdateUnit", unit);
        }

        var isSuccess = _unit.UpdateUnit(unit);
        if (isSuccess)
        {
            return RedirectToAction("ShowListUnit");
        }
        else
        {
            TempData["ErrorMessage"] = "error while update Unit!";
            return View("ShowUpdateUnit", unit);
        }
    }
}
