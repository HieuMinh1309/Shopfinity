using Microsoft.AspNetCore.Mvc;

namespace SSE_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}
