using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class TogAfgang
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Time { get; set; }
        [Required]
        public int Departure { get; set; }
        [Required]
        public int arrival { get; set; }

        public TogAfgang()
        {
            
        }

        public TogAfgang(int time, int departure, int arrival)
        {
            Time = time;
            Departure = departure;
            this.arrival = arrival;
        }
    }
}
