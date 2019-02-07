using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC02.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        // din kod här

        public async Task<bool> UserExist(string email)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            return user != null;

        }

        internal async Task<bool> DoesUserBelongToRole(string rolename, ClaimsPrincipal user)
        {
            //kolla om användaren har en viss roll, returnera sant eller falsk

            var user2 = await _userManager.GetUserAsync(user);

            bool userHasRole = await _userManager.IsInRoleAsync(user2, rolename);

            return userHasRole;
        }

        public async Task AddRoleToUser(string email, string role)
        {
            IdentityResult roleResult;
            var role2 = new IdentityRole(role);
            roleResult = await _roleManager.CreateAsync(role2);


            IdentityUser user = await _userManager.FindByEmailAsync(email);
            await _userManager.AddToRoleAsync(user, role);

        }

    }
}