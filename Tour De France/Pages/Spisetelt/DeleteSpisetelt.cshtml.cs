using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Spisetelt
{
    public class DeleteSpiseteltModel : PageModel
    {
        private SpiseteltService spiseteltService;

        [BindProperty]
        public Models.Spisetelt Spisetelt { get; set; }

        public DeleteSpiseteltModel(SpiseteltService spiseteltService)
        {
            this.spiseteltService = spiseteltService;
        }
        public IActionResult OnGet(int id)
        {
            Spisetelt = spiseteltService.GetSpisetelt(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Spisetelt = spiseteltService.GetSpisetelt(id);
            spiseteltService.DeleteSpisetelt(Spisetelt.Sid);
            return RedirectToPage("GetAllSpisetelt");
        }
    }
}
