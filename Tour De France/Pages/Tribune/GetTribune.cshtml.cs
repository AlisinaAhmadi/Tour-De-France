using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Tribune
{
    public class GetTribuneModel : PageModel
    {
        private TribuneService _tribuneService;
        public List<Models.Tribune> Tribunes { get; private set; }

        public GetTribuneModel(TribuneService tribuneService)
        {
            _tribuneService = tribuneService;
        }


        public IActionResult OnGet()
        {
            Tribunes = _tribuneService.GetTribunes().ToList();
            return Page();
        }
    }
}
