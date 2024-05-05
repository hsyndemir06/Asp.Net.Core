using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
