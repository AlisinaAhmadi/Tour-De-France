using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.VIP
{
    public class VIPModel : PageModel
    {
        private VIPService _vipService;
        public List<Models.VIP> Vips { get; private set; }

        public VIPModel(VIPService vipService)
        {
            _vipService = vipService;
        }

        public IActionResult OnGet()
        {
            Vips = _vipService.GetVIPs().ToList();
            return Page();
        }
    }
}
