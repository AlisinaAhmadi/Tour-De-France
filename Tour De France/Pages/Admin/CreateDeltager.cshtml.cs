using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Admin
{
    //[Authorize(Roles = "admin")]
    public class CreateDeltagerModel : PageModel
    {
        private DeltagerService _deltagerService;
        private PasswordHasher<string> passwordHasher;

        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        public CreateDeltagerModel(DeltagerService deltagerService)
        {
            _deltagerService = deltagerService;
            passwordHasher = new PasswordHasher<string>();
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _deltagerService.AddDeltager(new Deltager(Email, passwordHasher.HashPassword(null, Password)));
            return RedirectToPage("/Index");
        }
        public void OnGet()
        {
        }
    }
}
