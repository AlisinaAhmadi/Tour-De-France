using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.VIP
{
    public class DeleteVIPModel : PageModel
    {
        private VIPService _vipService;
        private List<Models.VIP> vips;

        [BindProperty] public Models.VIP Vip { get; set; }

        public DeleteVIPModel(VIPService vipService)
        {
            _vipService = vipService;
        }

        public IActionResult OnGet(int id)
        {
            Vip = _vipService.GetVIP(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Vip = _vipService.GetVIP(id);
            await _vipService.DeleteVIP(Vip.VIPId);
            return RedirectToPage("VIPOgMenu");
        }

    }
}
