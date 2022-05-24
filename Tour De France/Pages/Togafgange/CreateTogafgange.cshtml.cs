using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Togafgange
{
    //[Authorize(Roles = "admin")]
    public class CreateTogafgangeModel : PageModel
    {
        private TogafgangService togafgangeService;
        private List<Models.Togafgang> togafgangs;

        [BindProperty]
        public Models.Togafgang Togafgang { get; set; }

        public CreateTogafgangeModel(TogafgangService Tservice)
        {
            togafgangeService = Tservice;
            togafgangs = togafgangeService.GetTogafgange().ToList();
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

            await togafgangeService.AddTogafgange(Togafgang);
            return RedirectToPage("GetAllTogafgange");
        }
    }
}
