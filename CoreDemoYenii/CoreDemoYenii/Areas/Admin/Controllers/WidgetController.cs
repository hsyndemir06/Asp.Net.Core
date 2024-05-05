using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WidgetController : Controller
    {
       
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
