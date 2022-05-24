using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.VIP
{
    public class CreateVIPModel : PageModel
    {
        private VIPService _vipService;
        private List<Models.VIP> vips;

        [BindProperty] public Models.VIP Vip { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

        public CreateVIPModel(VIPService VService)
        {
            _vipService = VService;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _vipService.AddVIP(Vip);
            return RedirectToPage("/VIP/VIPOgMenu");
        }

    }
}
