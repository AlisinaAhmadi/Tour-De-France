using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Time { get; set; }
        [Required]
        public string Address { get; set; }
        public int People { get; set; }
        public int Mobil { get; set; }
        public string Email { get; set; }
        public int Eid { get; set; }


        public Event()
        {
            
        }
        public Event(int time, string address, int people, int mobil, string email, int eid)
        {
            Time = time;
            Address = address;
            People = people;
            Mobil = mobil;
            Email = email;
            Eid = eid;
        }
    }

    

    
}
