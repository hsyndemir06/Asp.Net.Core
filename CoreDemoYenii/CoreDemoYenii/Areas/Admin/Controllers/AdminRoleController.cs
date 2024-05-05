using CoreDemoYenii.Areas.Admin.Models;
using CoreDemoYenii.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoYenii.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")] //bu aktif oldugu sürece admin yetkisi olan kisiler sayfaya erisim saglayabilir
    public class AdminRoleController : Controller
    {
        RoleManager<AppRole> _roleManager;
        UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = roleModel.Name
                };

                var result = await _roleManager.CreateAsync(role);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError("", x.Description);
                }
            }
            return View(roleModel);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdate roleUpdate = new RoleUpdate
            {
                ID = values.Id,
                Name = values.Name
            };
            return View(roleUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdate p)
        {
            var values = _roleManager.Roles.Where(x => x.Id == p.ID).FirstOrDefault();
            values.Name = p.Name;
            var result = await _roleManager.UpdateAsync(values);

            if (result.Succeeded)
            {

                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();


            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RolesAssingViewModel> model = new List<RolesAssingViewModel>();
            foreach (var x in roles)
            {
                RolesAssingViewModel m = new RolesAssingViewModel();
                m.RoleID = x.Id;
                m.Name = x.Name;
                m.Exists = userRoles.Contains(x.Name);
                model.Add(m);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RolesAssingViewModel> model)
        {
            var userID = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userID);
            foreach (var x in model)
            {
                if (x.Exists)
                {
                    await _userManager.AddToRoleAsync(user, x.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, x.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
