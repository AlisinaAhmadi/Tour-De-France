using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Spisetelt
{
    public class GetAllSpisetelttModel : PageModel
    {
        private SpiseteltService _spiseteltService;

        public List<Models.Spisetelt> Spisetelts { get; private set; }
        [BindProperty] public DateTime Time { get; set; }
        [BindProperty] public string Food { get; set; }
        [BindProperty] public string Drink { get; set; }
        [BindProperty] public double Price { get; set; }


        public GetAllSpisetelttModel(SpiseteltService spiseteltService)
        {
            this._spiseteltService = spiseteltService;
        }

        public IActionResult OnGet()
        {
            Spisetelts = _spiseteltService.GetSpisetelts().ToList();
            return Page();
        }

        public IActionResult OnGetSortTime()
        {
            Spisetelts = _spiseteltService.SortByTime().ToList();
            return Page();
        }

    }
}
