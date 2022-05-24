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
    public class EditTogafgangeModel : PageModel
    {
        private TogafgangService _togafgangeService;
        [BindProperty] public Togafgang Togafgang { get; set; }

        public EditTogafgangeModel(TogafgangService togafgangeService)
        {
            _togafgangeService = togafgangeService;
        }
        public IActionResult OnGet(int id)
        {
            Togafgang = _togafgangeService.GetTogafgang(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _togafgangeService.EditTogafgange(Togafgang);
            return RedirectToPage("GetAllTogafgange");
        }
    }
}
