using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Musiktelt
{
    public class EditMusikteltModel : PageModel
    {
        private MusikteltService _musikteltService;

        [BindProperty]
        public Models.Musiktelt Musiktelt { get; set; }

        public EditMusikteltModel(MusikteltService musikteltService)
        {
            _musikteltService = musikteltService;
        }
        public IActionResult OnGet(int id)
        {
            Musiktelt = _musikteltService.GetMusiktelt(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _musikteltService.UpdateMusiktelt(Musiktelt);
            return RedirectToPage("GetAllMusiktelt");
        }
    }
}
