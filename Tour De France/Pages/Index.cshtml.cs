using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Service;
using Tour_De_France.Models;

namespace Tour_De_France.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //private DeltagerService deltagerService;

        //public List<Models.Deltager> Deltagere { get; set; }

        public IndexModel(ILogger<IndexModel> logger/*, DeltagerService deltagerService*/)
        {
            _logger = logger;
            //this.deltagerService = deltagerService; 
        }

        //public IActionResult OnGet()
        //{
        //    Deltagere = deltagerService.GetDeltager().ToList();
        //    return Page();
        //}
    }
}
