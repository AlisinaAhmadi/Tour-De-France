using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class VIP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VIPId { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        public double Price { get; set; }
        public bool Champagne { get; set; }


        public VIP()
        {
            
        }

        public VIP(int vipId, string titel, string description, double price)
        {
            VIPId = vipId;
            Titel = titel;
            Description = description;
            Price = price;
        }
    }
}