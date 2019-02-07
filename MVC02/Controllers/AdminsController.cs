using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVC02.Data;
using MVC02.Models.ViewModels;
using MVC02.Services;

namespace Mvc02.Controllers
{

    public class AdminsController : Controller
    {
        private readonly AuthService _auth;


        public AdminsController(AuthService auth)
        {
            _auth = auth;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddRoleForUser(AddRoleVm addrole)
        {

            var truefalse = _auth.UserExist(addrole.Email);

            if (await truefalse)
            {
                if (!ModelState.IsValid)
                {
                    return View("Index");
                }
                await _auth.AddRoleToUser(addrole.Email, addrole.Role);
                return View("SuccesAddRole", addrole);

            }

            else
            {
                ModelState.AddModelError("UserDontExist", $"Användaren med email {addrole.Email} finns inte.");
                return View("Index");
            }
            
        }
    }
}