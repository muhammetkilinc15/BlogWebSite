using Asp.net_Core_Web_Application.Areas.Admin.Models;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Web_Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "ADMİN")]
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = roleManager.Roles.ToList();

            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole();
                role.Name = model.name;

                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateVİewModel role = new RoleUpdateVİewModel();
            role.Id = values.Id;
            role.name = values.Name;
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateVİewModel model)
        {
            var values = roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();
            values.Name = model.name;
            var result = await roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
            var result = await roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = userManager.Users.Where(x=>x.Id == id).FirstOrDefault();
            var roles = roleManager.Roles.ToList();

            TempData["userID"] = user.Id;
            var usrRoles = await userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleID = role.Id;
                m.Name = role.Name;
                m.Exists = usrRoles.Contains(role.Name);
                model.Add(m);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int) TempData["userID"];
            var user = userManager.Users.Where(x=>x.Id==userId).FirstOrDefault();

            foreach(var item in model)
            {
                if(item.Exists)
                {
                    await userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }


            return RedirectToAction("UserRoleList");
        }
    }
}
