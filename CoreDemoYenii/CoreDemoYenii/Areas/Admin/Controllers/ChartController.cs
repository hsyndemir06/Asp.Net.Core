using CoreDemoYenii.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Teknoloji",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 25
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 36
            });
            list.Add(new CategoryClass
            {
                categoryname = "Cinema",
                categorycount = 3
            });
            return Json(new { jsonlist = list });
        }
    }
}
