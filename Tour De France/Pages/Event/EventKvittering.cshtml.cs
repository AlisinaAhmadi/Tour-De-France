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
        public DeltagerService _deltagerService { get; set; }
        public IEnumerable<Models.EventOrder> MyEventOrders { get; set; }

        public bool VIP { get; set; }

        public EventKvitteringModel(DeltagerService deltagerService)
        {
            _deltagerService = deltagerService;
        }

        public async Task<IActionResult> OnGet()
        {
            Models.Deltager currentUser = _deltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
            MyEventOrders = _deltagerService.GetOrdersByDeltager(currentUser).Result.EventOrders;
            return Page();
        }
    }
}
