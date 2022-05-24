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
    public class GetParkeringspladserModel : PageModel
    {
        private ParkeringspladsService parkeringspladsService;

        public List<Models.Parking_plads> ParkingPlads { get; private set; }

        [BindProperty] public int Id { get; set; }
        [BindProperty] public bool Free { get; set; }

        public GetParkeringspladserModel(ParkeringspladsService parkeringspladsService)
        {
            this.parkeringspladsService = parkeringspladsService;
        }

        public IActionResult OnGet()
        {
            ParkingPlads = parkeringspladsService.GetParkeringsplads().ToList();
            return Page();
        }

        public IActionResult OnGetSortById()
        {
            ParkingPlads = parkeringspladsService.SortById().ToList();
            return Page();
        }

        public IActionResult OnGetSortByIdDescending()
        {
            ParkingPlads = parkeringspladsService.SortByIdDescending().ToList();
            return Page();
        }

    }
}