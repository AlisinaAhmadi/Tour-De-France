using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Tribune
{
    public class CreateTribuneModel : PageModel
    {
        private TribuneService _tribuneService;
        private List<Models.Tribune> tribunes;

        [BindProperty]
        public Models.Tribune Tribune { get; set; }

        public CreateTribuneModel(TribuneService tribuneService)
        {
            _tribuneService = tribuneService;
                tribunes = _tribuneService.GetTribunes().ToList();
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
            await _tribuneService.AddTribune(Tribune);
            return RedirectToPage("GetTribune");
        }
    }
}
