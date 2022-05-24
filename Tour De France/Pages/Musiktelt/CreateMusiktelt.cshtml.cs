using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Musiktelt
{
    public class CreateMusikteltModel : PageModel
    {
        private MusikteltService musikteltService;
        private List<Models.Musiktelt> musiktelts;

        [BindProperty]
        public Models.Musiktelt Musiktelt { get; set; }

        public CreateMusikteltModel(MusikteltService Tservice)
        {
            musikteltService = Tservice;
            musiktelts= musikteltService.GetMusiktelts().ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await musikteltService.AddMusiktel(Musiktelt);
            return RedirectToPage("GetAllMusiktelt");
        }

    }
}
