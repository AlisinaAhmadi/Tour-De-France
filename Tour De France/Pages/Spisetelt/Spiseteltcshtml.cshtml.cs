using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Spisetelt
{
    public class SpiseteltcshtmlModel : PageModel
    {
        public List<Models.Spisetelt> Spisetelts;
        public class GetSpiseteltModel : PageModel
        {
            private SpiseteltService spiseteltService;
            public List<Models.Spisetelt> Spisetelts { get; private set; }
            [BindProperty] public string FilterString { get; set; }

            public GetSpiseteltModel(SpiseteltService spiseteltService) //Dependency Injection
            {
                this.spiseteltService = spiseteltService;
            }

            public IActionResult OnGet()
            {
                Spisetelts = spiseteltService.GetSpisetelts().ToList();
                return Page();
            }

        }
    }
}
