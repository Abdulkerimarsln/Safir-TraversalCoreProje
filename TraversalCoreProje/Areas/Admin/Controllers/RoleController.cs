using DocumentFormat.OpenXml.Office.CustomUI;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
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
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            AppRole role = new AppRole()
            {
                Name = createRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return View();

            }

        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(values);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values= _roleManager.Roles.FirstOrDefault(y => y.Id == id);
            UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
            {
                RoleID = values.Id,
                RoleNameUpdate=values.Name
            };
            return View(updateRoleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
           var values= _roleManager.Roles.FirstOrDefault(x=>x.Id==updateRoleViewModel.RoleID);
            values.Name=updateRoleViewModel.RoleNameUpdate;
            await _roleManager.UpdateAsync(values);
            return RedirectToAction("Index");
        }
        public IActionResult UserList()
        {
            var values= _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;
            var roles= _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var role in roles) 
            {
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel()
                {
                    RoleID = role.Id,
                    RoleName = role.Name,
                    RoleExist = userRoles.Contains(role.Name)
                    
                };
                roleAssignViewModels.Add(roleAssignViewModel);
            }
            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid =(int)TempData["userid"];
            var user =_userManager.Users.FirstOrDefault(x=>x.Id == userid);
            foreach (var item in model)
            {
                if (item.RoleExist) 
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");

        }
    }
}
