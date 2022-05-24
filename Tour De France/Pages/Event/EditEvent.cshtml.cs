using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Event
{
    public class EditEventModel : PageModel
    {
        private EventService _eventService;
        [BindProperty]
        public Models.Event Event { get; set; }

        public EditEventModel(EventService eventService)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _eventService.EditEvent(Event);
            return RedirectToPage("GetEvent");
        }
    }
}
