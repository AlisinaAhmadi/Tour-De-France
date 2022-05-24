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
    public class GetEventModel : PageModel
    {
        private EventService _eventService;
        public List<Models.Event> Events { get; set; }

        public GetEventModel(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult OnGet()
        {
            Events = _eventService.GetEvents().ToList();
            return Page();
        }
    }
}
