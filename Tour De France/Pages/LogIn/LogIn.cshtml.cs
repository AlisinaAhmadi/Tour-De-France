using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.LogIn
{
    public class LogInModel : PageModel
    {
        private DeltagerService _deltagerService;



        [BindProperty]
        public string Email { get; set; }
        [BindProperty,DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnPost()
        {
            List<Deltager> deltagere = _deltagerService.Deltagere;
            foreach (Deltager deltagers in deltagere)
            {
                if (Email == deltagers.Email)
                {
                    //var passwordHasher = new PasswordHasher<string>();
                    //if (passwordHasher.VerifyHashedPassword(null, deltagers.Password, Password) == PasswordVerificationResult.Success)
                    {
                        //LoggedInUser = user;
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, Email)
                        };

                        if (Email == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));

                        var claimsIdentity =
                            new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Event/GetAllEvents");
                    }
                }
            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}
