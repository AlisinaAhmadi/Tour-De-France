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
        [BindProperty] public Models.Deltager Deltager { get; set; }
        private DeltagerService _deltagerService;
        private PasswordHasher<string> passwordHasher;

        //[Required(ErrorMessage = "Feltet må ikke være tomt!")]
        //[Range(typeof(string), "2", "50", ErrorMessage = "Navnet skal være mellem {1} og {2} tegn")]
        [BindProperty]
        public string Name { get; set; }

        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{+45 00 00 00 00}")]
        [BindProperty]
        public string Mobil { get; set; }

        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        [EmailAddress]
        [DataType(DataType.EmailAddress, ErrorMessage = "Ikke en rigtig email!")]
        [BindProperty]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Feltet må ikke være tomt!")]
        //[Range(4, 50, ErrorMessage = "Passwordet skal være imellem {1} og {2} tegn")]
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty] public bool VIP { get; set; }

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
            await _deltagerService.AddDeltager(new Models.Deltager(Name, Mobil,Email,passwordHasher.HashPassword(null,Password)));
            return RedirectToPage("/Event/GetEvent");
        }
    }
}
