using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Togafgange
{
    public class GetAllTogafgangeModel : PageModel
    {
        private TogafgangService togafgangeService;
        public List<Models.Togafgang> togafgangs { get; private set; }
        [BindProperty] public string Arrival { get; set; }
        [BindProperty] public string Departure { get; set; }


        public GetAllTogafgangeModel(TogafgangService togafgangeService)
        {
            this.togafgangeService = togafgangeService;
        }

        public IActionResult OnGet()
        {
            togafgangs = togafgangeService.GetTogafgange().ToList();
            return Page();
        }

        public IActionResult OnGetSortByArrival()
        {
            togafgangs = togafgangeService.SortByArrival().ToList();
            return Page();
        }

        public IActionResult OnGetSortByArrivalDescending()
        {
            togafgangs = togafgangeService.SortByArrivalDescending().ToList();
            return Page();
        }

        public IActionResult OnGetSortByDeparture()
        {
            togafgangs = togafgangeService.SortByDeparture().ToList();
            return Page();
        }

        public IActionResult OnGetSortByDepartureDescending()
        {
            togafgangs = togafgangeService.SortByDepartureDescending().ToList();
            return Page();
        }
    }
}
