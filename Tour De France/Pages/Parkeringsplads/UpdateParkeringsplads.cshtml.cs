using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Parkeringsplads
{
    public class UpdateParkeringspladsModel : PageModel
    {

        private ParkeringspladsService parkeringspladsService;

        [BindProperty] public Models.Parking_plads ParkeringsPlads { get; set; }

        [BindProperty] public int Id { get; set; }
        [BindProperty] public bool Free { get; set; }

        public UpdateParkeringspladsModel(ParkeringspladsService ppS)
        {
            this.parkeringspladsService = ppS;
        }

        public IActionResult OnGet(int ppid)
        {
            ParkeringsPlads = parkeringspladsService.GetParkingsplads(ppid);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await parkeringspladsService.UpdateParkeringspladsAsync(ParkeringsPlads);
            return RedirectToPage("GetParkeringspladser");
        }
    }
}


