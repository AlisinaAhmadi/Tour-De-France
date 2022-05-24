using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Spisetelt
{
    public class EiditSpiseteltModel : PageModel
    {
        private SpiseteltService _spiseteltService;
        

        [BindProperty]
        public Models.Spisetelt Spisetelt { get; set; }

        public EiditSpiseteltModel(SpiseteltService spiseteltService)
        {
           _spiseteltService  = spiseteltService;
        }
        public IActionResult OnGet(int id)
        {
            Spisetelt = _spiseteltService.GetSpisetelt(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _spiseteltService.UpdateSpisetelt(Spisetelt);
            return RedirectToPage("GetAllSpisetelt");
        }
    }
}
