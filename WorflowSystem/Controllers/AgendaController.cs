using Microsoft.AspNetCore.Mvc;

namespace Worflow.Controllers
{
    public class AgendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
