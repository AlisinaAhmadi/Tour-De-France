using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Tribune
{
    public class EditTribuneModel : PageModel
    {
        private TribuneService _tribuneService;

        [BindProperty]
        public Models.Tribune Tribune { get; set; }

        public EditTribuneModel(TribuneService tribuneService)
        {
            _tribuneService = tribuneService;
        }
        public IActionResult OnGet(int id)
        {
            Tribune = _tribuneService.GetTribune(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _tribuneService.EditTribune(Tribune);
            return RedirectToPage("GetTribune");
        }
    }
}
