using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC02.Data;
using MVC02.Models.ViewModels;
using MVC02.Services;

namespace Mvc02.Controllers
{

    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthService _auth;

        public AdminsController(ApplicationDbContext context, AuthService auth)
        {
            _context = context;
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddRoleForUser(AddRoleVm addrole) // Tog bort AddRoleVm addrole i parentesen
        {
            //Vi vill kolla om användaren har rollen sedan innan


            //var truefalse = _auth.UserExist(addrole.Email);

            //var vm = new AddRoleVm();
            addrole.AllRoles = _context.Roles.Select(role => new SelectListItem() { Text = role.Name, Value = role.Id.ToString() });
           addrole.AllUsers = _context.Users.Select(user => new SelectListItem() { Text = user.Email, Value = user.Id.ToString() });
            return View("Index", addrole);

            //if (await truefalse)
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return View("Index");
            //    }

            //    await _auth.AddRoleToUser(addrole.Email, addrole.Role);
            //    return View("SuccesAddRole", addrole);

            //}

            //else
            //{
            //    ModelState.AddModelError("UserDontExist", $"Användaren med email {addrole.Email} finns inte.");
            //    return View("Index");
            //}

        }
    }
}