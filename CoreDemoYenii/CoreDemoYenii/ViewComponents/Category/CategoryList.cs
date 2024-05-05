using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDemoYenii.ViewComponents.Category
{
    public class CategoryList: ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryReposityory());

        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
