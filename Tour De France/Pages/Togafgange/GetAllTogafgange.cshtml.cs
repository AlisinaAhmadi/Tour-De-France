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
        private TogafgangeService togafgangeService;
        public List<Models.Togafgang> togafgangs { get; private set; }
        [BindProperty] public string ArrivalK { get; set; }
        [BindProperty] public string DepartureK { get; set; }
        [BindProperty] public string ArrivalN { get; set; }
        [BindProperty] public string DepartureN { get; set; }


        public GetAllTogafgangeModel(TogafgangeService togafgangeService)
        {
            this.togafgangeService = togafgangeService;
        }

        public IActionResult OnGet()
        {
            togafgangs = togafgangeService.GetTogafgange().ToList();
            return Page();
        }

        public IActionResult OnGetSortByArrivalK()
        {
            togafgangs = togafgangeService.SortByArrivalK().ToList();
            return Page();
        }

        public IActionResult OnGetSortByArrivalKDescending()
        {
            togafgangs = togafgangeService.SortByArrivalKDescending().ToList();
            return Page();
        }

        public IActionResult OnGetSortByArrivalN()
        {
            togafgangs = togafgangeService.SortByArrivalN().ToList();
            return Page();
        }

        public IActionResult OnGetSortByArrivalNDescending()
        {
            togafgangs = togafgangeService.SortByArrivalNDescending().ToList();
            return Page();
        }
    }
}
