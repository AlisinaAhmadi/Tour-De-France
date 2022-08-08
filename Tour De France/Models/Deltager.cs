using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Tour_De_France.Models
{
    public class Deltager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeltagerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobil { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool VIP { get; set; }
      

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<EventOrder> EventOrders { get; set; }

        public Deltager()
        {
            
        }
        public Deltager(string name, string mobil,string email,string password)
        {
            Name = name;
            Mobil = mobil;
            Email = email;
            Password = password;
            
        }
    }
}
