using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tour_De_France.Pages.Parkeringsplads
{
    //[Authorize(Roles = "admin")]
    public class CreateParkeringspladserModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
