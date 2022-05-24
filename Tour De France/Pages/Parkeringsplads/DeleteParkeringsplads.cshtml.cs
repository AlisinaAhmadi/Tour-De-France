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
    public class DeleteParkeringspladsModel : PageModel
    {

        private ParkeringspladsService parkeringspladsService;

        [BindProperty]
        public Models.Parking_plads ParkingPlads { get; set; }

        public DeleteParkeringspladsModel(ParkeringspladsService ppS)
        {
            this.parkeringspladsService = ppS;
        }

        public IActionResult OnGet(int id)
        {
            ParkingPlads = parkeringspladsService.GetParkingsplads(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            ParkingPlads = parkeringspladsService.GetParkingsplads(id);
            await parkeringspladsService.DeleteParkeringspladsAsync(ParkingPlads.ppId);
            return RedirectToPage("GetParkeringspladser");
        }
    }
}

