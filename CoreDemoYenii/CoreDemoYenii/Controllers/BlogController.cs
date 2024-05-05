using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;


namespace CoreDemoYenii.Controllers
{
	public class BlogController : Controller
	{
        CategoryManager cm = new CategoryManager(new EfCategoryReposityory());
        BlogManager bm = new BlogManager(new EfBlogRepository());
		public IActionResult Index()
		{
			var values = bm.GetBlogListWithCategory();
			return View(values);
		}

		public IActionResult BlogReadAll(int id)
		{
			ViewBag.x = id;
			var values =bm.GetBlogByID(id);
			return View(values);
		}

		public IActionResult BlogListByWriter()
		{
			var values = bm.CategoryName(1);
			return View(values);
		}

		[HttpGet]
		public IActionResult AddBlog()
		{
			
			List<SelectListItem> categoryvalues = (from x in cm.GetList()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString(),
												   }).ToList();
			ViewBag.cv = categoryvalues;
			return View();
		}

		[HttpPost]
		public IActionResult AddBlog(Blog p)
		{
            BlogValidator bv = new BlogValidator();
			ValidationResult results = bv.Validate(p);
			if(results.IsValid)
			{
				p.BlogStatus = true;
				p.BlogCreateDate = DateTime.Today;
				p.WriterID = 1;
				bm.BlogAdd(p);
            return RedirectToAction("BlogListByWriter", "Blog");
			}
			else
			{
				foreach (var x in results.Errors)
				{
					ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
				}
			}
			return View();
		}

		public IActionResult DeleteBlog(int id)
		{
			var blogvalue = bm.GetByID(id);
			bm.BlogDelete(blogvalue);
			return RedirectToAction("BlogListByWriter");
		}

		[HttpGet]
		public IActionResult EditBlog(int id)
		{
			var blogvalue=bm.GetByID(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
		}

		[HttpPost]
		public IActionResult EditBlog(Blog p)
		{
			p.WriterID = 1;
			p.BlogCreateDate = DateTime.Today;
			p.BlogStatus = true;
			bm.BlogUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }

    }
}
