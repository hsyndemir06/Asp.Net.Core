using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryReposityory());

        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
