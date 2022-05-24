using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Event
{
    public class DeleteEventModel : PageModel
    {
        private EventService _eventService;

        [BindProperty]
        public Models.Event Event { get; set; }

        public DeleteEventModel(EventService eventService)
        {
            _eventService = eventService;
        }
        public IActionResult OnGet(int id)
        {
            Event = _eventService.GetEvent(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Event = _eventService.GetEvent(id);
            await _eventService.DeleteEvent(Event.EventId);
            return RedirectToPage("GetEvent");
        }
    }
}
