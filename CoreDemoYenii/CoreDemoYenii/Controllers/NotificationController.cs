using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var value = nm.GetList();
            return View(value);
        }
    }
}
