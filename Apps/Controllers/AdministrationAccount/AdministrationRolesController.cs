using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apps.Models;
using Apps.Models.RoleViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Apps.Controllers.AdministrationAccount
{

    public class AdministrationRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationRolesController(RoleManager<IdentityRole> roleManager,
                                             UserManager<ApplicationUser>userManager)
        {
              this.roleManager = roleManager;
              this.userManager = userManager;
        }

        // GET: AdministrationRoles
        public ActionResult Index()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        // GET: AdministrationRoles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministrationRoles/Create
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: AdministrationRoles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(CreateRoleViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityRole identityRole = new IdentityRole {

                        Name = model.RoleName
                    };

                    IdentityResult res = await roleManager.CreateAsync(identityRole);

                    if(res.Succeeded)
                    {
                        return RedirectToAction("Index", "AdministrationRoles");
                    }

                    foreach (IdentityError error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }



                return View(model);
            }
            catch
            {
                return View();
            }
        }
          
        // GET: AdministrationRoles/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            // GetClaimsAsync retunrs the list of user Claims
            var roleClaims = await roleManager.GetClaimsAsync(role);
            // GetRolesAsync returns the list of user Roles
            //var userRoles = await roleManager.GetUsersAsync(user);
            var model = new EditRoleViewModel
            {

                Id = role.Id,
                RoleName = role.Name,
            
            };

            foreach(var user in userManager.Users)
            {
               if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        // POST: Administration/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Id = model.Id;
                role.Name = model.RoleName;
                

                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        // GET: AdministrationRoles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministrationRoles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteRole(string id, IFormCollection collection)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Index");
            }
        }
    }
}