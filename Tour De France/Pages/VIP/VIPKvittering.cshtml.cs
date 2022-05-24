using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.VIP
{
    public class VIPKvitteringModel : PageModel
    {
        private DeltagerService _deltagerService;
        public IEnumerable<Models.Order> VIPOrders { get; set; }


        public VIPKvitteringModel(DeltagerService deltagerService)
        {
            _deltagerService = deltagerService;
        }
        public async Task<IActionResult> OnGet()
        {
            Models.Deltager currentUser = _deltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
            VIPOrders = _deltagerService.GetOrdersByDeltager(currentUser).Result.Orders;
            return Page();
        }
    }
}
