using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.Deltager
{
    public class DeletePasswordModel : PageModel
    {
        private DeltagerService _deltagerService;
        private List<Models.Deltager> deltagers;

        [BindProperty] public Models.Deltager Deltager { get; set; }

        public DeletePasswordModel(DeltagerService deltagerService)
        {
            _deltagerService = deltagerService;
        }

        public IActionResult OnGet(int id)
        {
            Deltager = _deltagerService.GetDeltager(id);
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Deltager = _deltagerService.GetDeltager(id);
            await _deltagerService.DeletePassword(Deltager.Password);
            return RedirectToPage("/Deltager/ChangePassword");
        }
    }
}
