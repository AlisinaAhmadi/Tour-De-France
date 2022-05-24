using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Event
{
    public class CreateEventModel : PageModel
    {
        private EventService _eventService;
        private List<Models.Event> events;

        [BindProperty]
        public Models.Event Event  { get; set; }

        public CreateEventModel(EventService eventService)
        {
            _eventService = eventService;
            events = _eventService.GetEvents().ToList();
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            } 
            _eventService.AddEvent(Event);
            return RedirectToPage("GetEvent");
        }
    }
}
