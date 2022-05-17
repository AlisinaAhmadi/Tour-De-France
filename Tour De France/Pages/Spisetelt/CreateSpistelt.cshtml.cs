using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Spisetelt
{
      
    [Authorize(Roles = "Admin")]
    public class CreateSpiseteltModel : PageModel
    {
        public List<Models.Spisetelt> Spisetelts;
        private SpiseteltService spiseteltService;
        private List<Models.Spisetelt> spiseteltsList;
        private List<Models.Spisetelt> spisetelts;

        public CreateSpiseteltModel(IService spisetetService)
        {
            this.spiseteltService = spiseteltService;
            spiseteltsList = spiseteltService.GetSpisetelts().ToList();
        }

        public Models.Spisetelt Spisetelt{ get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            spiseteltService.AddSpisetelt(Spisetelt);
            return RedirectToPage("GetSpisetelt");
        }

    }
}
