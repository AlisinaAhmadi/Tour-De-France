using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Deltager
{
    public class ChangePasswordModel : PageModel
    {
        private DeltagerService _deltagerService;
        private List<Models.Deltager> deltagers;
        private PasswordHasher<string> passwordHasher;

        [BindProperty] public Models.Deltager Deltager { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Mobil { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty] 
        public bool VIP { get; set; }

        public ChangePasswordModel(DeltagerService deltagerService)
        {
            _deltagerService = deltagerService;
            passwordHasher = new PasswordHasher<string>();
        }

        public IActionResult OnGet(int id)
        {
            Deltager = _deltagerService.GetDeltager(id);
            return Page();
        }
        //public async Task<IActionResult> OnPost(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    await _deltagerService.UpdatePasword(Deltager);
        //    return RedirectToPage("/Event/GetEvent");
        //}
        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _deltagerService.AddDeltager(new Models.Deltager(Name, Mobil,Email, passwordHasher.HashPassword(null, Password)));
            return RedirectToPage("/Event/GetEvent");
        }
    }
}
