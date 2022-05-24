using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class Togafgang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TogafgangId { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        [DisplayFormat(DataFormatString = "{dd-mm-yyyy}")]
        public DateTime Arrival { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        [DisplayFormat(DataFormatString = "{dd-mm-yyyy}")]
        public DateTime Departure { get; set; }
   
      

        public Togafgang()
        {
            
        }
        
        public Togafgang(int togafgangId, DateTime arrival, DateTime departure)
        {
            TogafgangId = togafgangId;
            Arrival = arrival;
            Departure = departure;
        }

    }
}
