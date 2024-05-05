using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.Controllers
{
    
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager( new EfWriterRepository());


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Index(Writer p)
		{
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if(results.IsValid)
            {
            p.WriterStatus = true;
            p.WriterAbout = "Test";
            wm.TAdd(p);
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
	}
}
