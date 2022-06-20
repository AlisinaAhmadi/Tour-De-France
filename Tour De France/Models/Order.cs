using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tour_De_France.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        [Range(Int32.MaxValue, 1, ErrorMessage = "Kan bestille en!")]
        public int Count { get; set; }
        [AllowNull]
        public bool Champagne { get; set; }
        [Required]
        public int DeltagerId { get; set; }
        public Deltager Deltager { get; set; }
        [Required]
        public int VIPId { get; set; }
        public VIP VIP { get; set; }

        public Order(Deltager deltager, VIP vip)
        {
            Deltager = deltager;
            VIP = vip;
        }

        public Order()
        {
                
        }
    }
}
