using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Event
{
    public class TilmeldModel : PageModel
    {
        private EventService _eventService;
        private DeltagerService _deltagerService;
        private EventOrderService _eventOrderService;
        public Models.Event Event { get; set; }
        public Models.Deltager Deltager { get; set; }
        public Models.EventOrder EventOrder { get; set; } = new EventOrder();

        [BindProperty] public int Count { get; set; }

        public TilmeldModel(EventService eventService, DeltagerService deltagerService, EventOrderService eventOrderService)
        {
            _eventService = eventService;
            _deltagerService = deltagerService;
            _eventOrderService = eventOrderService;
        }
        public void OnGet(int id)
        {
            Event = _eventService.GetEvent(id);
            Deltager = _deltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Event = _eventService.GetEvent(id);
            Deltager = _deltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
            EventOrder.DeltagerId = Deltager.DeltagerId;
            EventOrder.EventId = Event.EventId;
            EventOrder.Count = Count;
            _eventOrderService.AddEventOrder(EventOrder);
            return RedirectToPage("../Event/EventKvittering");
        }
    }
}
