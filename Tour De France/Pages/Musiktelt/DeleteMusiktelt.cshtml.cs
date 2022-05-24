using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Musiktelt
{
    public class DeleteMusikteltModel : PageModel
    {
        private MusikteltService _musikteltService;

        [BindProperty]
        public Models.Musiktelt Musiktelt { get; set; }

        public DeleteMusikteltModel(MusikteltService musikteltService)
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
            Musiktelt = _musikteltService.GetMusiktelt(id);
            _musikteltService.DeleteMusiktelt(Musiktelt.Mid);
            return RedirectToPage("GetAllMusiktelt");
        }

    }
}
