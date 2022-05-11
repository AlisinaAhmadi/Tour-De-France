using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Mockdata;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Event
{
    public class GetAllEventsModel : PageModel
    {
        private EventService evenService;
        public List<Models.Event> Evens { get; private set; }
        [BindProperty] public string FilterString { get; set; }

        public GetAllEventsModel(EventService evenService) //Dependency Injection
        {
            this.evenService = evenService;
        }

        public IActionResult OnGet()
        {
            Evens = evenService.GetEvens().ToList();
            return Page();
        }

       
    }





}
