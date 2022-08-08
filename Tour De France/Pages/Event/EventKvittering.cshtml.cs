using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Event
{
    public class EventKvitteringModel : PageModel
    {
        public DeltagerService DeltagerService { get; set; }
        public IEnumerable<Models.EventOrder> EventOrders { get; set; }

        public EventKvitteringModel(DeltagerService deltagerService)
        {
            DeltagerService = deltagerService;
        }

        public async Task<IActionResult> OnGet()
        {
            Models.Deltager currentUser = DeltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
            EventOrders = DeltagerService.GetOrdersByDeltager(currentUser).Result.EventOrders;
            return Page();
        }
    }
}
