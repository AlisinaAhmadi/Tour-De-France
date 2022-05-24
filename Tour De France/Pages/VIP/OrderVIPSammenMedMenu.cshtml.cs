using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tour_De_France.Models;
using Tour_De_France.Service;

namespace Tour_De_France.Pages.VIP
{
    public class OrderVIPSammenMedMenuModel : PageModel
    {
        private VIPService _vipService;
        private DeltagerService _deltagerService;
        private OrderService _orderService;

        public Models.Deltager Deltager { get; set; }
        public Models.VIP VIP { get; set; }
        public Models.Order Order { get; set; } = new Models.Order();
        //[Range(1, 1, ErrorMessage = "Kan kun melde dig til engang!")]
        [BindProperty] public int Count { get; set; }
        [BindProperty] public bool Champagne { get; set; }

        public OrderVIPSammenMedMenuModel(VIPService vipService, DeltagerService deltagerService, OrderService orderService)
        {
            _vipService = vipService;
            _deltagerService = deltagerService;
            _orderService = orderService;
        }

        public void OnGet(int id)
        {
            VIP = _vipService.GetVIP(id);
            Deltager = _deltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            VIP = _vipService.GetVIP(id);
            Deltager = _deltagerService.GetDeltagerByName(HttpContext.User.Identity.Name);
            Order.DeltagerId = Deltager.DeltagerId;
            Order.VIPId = VIP.VIPId;
            Order.Count = Count;
            _orderService.AddOrder(Order);
            return RedirectToPage("../VIP/VIPKvittering");
        }
     }
}
