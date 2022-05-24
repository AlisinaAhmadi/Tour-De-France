using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
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

        public LogInModel(DeltagerService deltagerService)
        {
            _deltagerService = deltagerService;
        }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty,DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string Message { get; set; }

        public async Task<IActionResult> OnPost()
        {
            List<Models.Deltager> deltagere = _deltagerService.Deltagere;
            foreach (Models.Deltager deltagers in deltagere)
            {
                if (Name == deltagers.Name)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    if (passwordHasher.VerifyHashedPassword(null, deltagers.Password, Password) == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, Name)
                        };

                        if (Name == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));

                        var claimsIdentity =
                            new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Event/GetEvent");
                    }
                }
            }
            Message = "Ugyldigt Password eller Navn";
            return Page();
        }
    }
}
