using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Spisetelt
{
    public class CreateSpiseteltModel : PageModel
    {
        private SpiseteltService spiseteltService;
        private List<Models.Spisetelt> spisetelts;

        [BindProperty]
        public Models.Spisetelt Spisetelt { get; set; }

        public CreateSpiseteltModel(SpiseteltService Tservice)
        {
            spiseteltService = Tservice;
            spisetelts = spiseteltService.GetSpisetelts().ToList();
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

            await spiseteltService.AddSpisetelt(Spisetelt);
            return RedirectToPage("GetAllSpisetelt");
        }
    }
}
