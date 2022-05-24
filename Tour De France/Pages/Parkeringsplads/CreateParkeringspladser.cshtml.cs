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
    //[Authorize(Roles = "admin")]
    public class CreateParkeringspladserModel : PageModel
    {
        private ParkeringspladsService parkeringspladsService;
        private List<Models.Parking_plads> parkeringsplads;


        [BindProperty]
        public Models.Parking_plads ParkeringsPlads { get; set; }



        public CreateParkeringspladserModel(ParkeringspladsService ppS)
        {
            parkeringspladsService = ppS;
            parkeringsplads = parkeringspladsService.GetParkeringsplads().ToList();
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

            await parkeringspladsService.AddParkeringspladsAsync(ParkeringsPlads);
            return RedirectToPage("GetParkeringspladser");
        }

    }
}