using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Musiktelt
{
    public class GetAllMusikteltModel : PageModel
    {
        private MusikteltService _musikteltService;

        public List<Models.Musiktelt> musiktelts { get; private set; }
        [BindProperty] public DateTime Time { get; set; }
        [BindProperty] public string Band { get; set; }
        [BindProperty] public string Drink { get; set; }
        [BindProperty] public double Price { get; set; }

        public GetAllMusikteltModel(MusikteltService musikteltService)
        {
            _musikteltService = musikteltService;
        }

        public IActionResult OnGet()
        {
            musiktelts = _musikteltService.GetMusiktelts().ToList();
            return Page();
        }

        public IActionResult OnGetSortTime()
        {
            musiktelts = _musikteltService.SortByTime().ToList();
            return Page();
        }

    }
}

