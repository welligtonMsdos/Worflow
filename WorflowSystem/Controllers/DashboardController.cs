using Microsoft.AspNetCore.Mvc;

namespace Worflow.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
public class DashboardController : Controller
{
    public IActionResult GetDashboard()
    {
        return View();
    }
}
