using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Event
{
    public class CreateEventModel : PageModel
    {

        private EventService evenServicecs;
        private List<Models.Event> evensList;

        public CreateEventModel(EventService evenServicecs)
        {
            this.evenServicecs = evenServicecs;
            evensList = evenServicecs.GetEvens().ToList();
        }

        public Models.Event Even { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        }
    }
