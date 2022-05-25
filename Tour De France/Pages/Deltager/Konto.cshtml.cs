using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Deltager
{
    public class KontoModel : PageModel
    {
        private DeltagerService _deltagerService;
        public List<Models.Deltager> Deltagers { get; set; }
        [BindProperty] public Models.Deltager Deltager { get; set; }
        public KontoModel(DeltagerService deltagerService)
        {
            _deltagerService = deltagerService;
        }

        public void OnGet()
        {
            Deltager = _deltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
        }
    }
}
