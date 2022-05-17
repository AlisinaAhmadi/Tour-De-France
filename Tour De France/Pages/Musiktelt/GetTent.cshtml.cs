using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Musiktelt
{
    public class GetMusikteltModel : PageModel
    {
        private MusikteltService musikteltService;
        public List<Models.Musiktelt> Musiktelts { get; private set; }
        [BindProperty] public string FilterString { get; set; }

        public GetMusikteltModel(MusikteltService musikteltService) //Dependency Injection
        {
            this.musikteltService = musikteltService;
        }

        public IActionResult OnGet()
        {
            Musiktelts = musikteltService.GetEvens().ToList();
            return Page();
        }

    }
}

