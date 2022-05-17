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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Tid { get; set; }
        [AllowNull]
        public string ArrivalK { get; set; }
        [AllowNull]
        public string DepartureK { get; set; }
        [AllowNull]
        public string ArrivalN { get; set; }
        [AllowNull]
        public string DepartureN { get; set; }

        public Togafgang()
        {
            
        }
        
        public Togafgang(string arrivalN, string departureN, string arrivalK, string departureK)
        {
            ArrivalN = arrivalN;
            DepartureN = departureN;
            ArrivalK = arrivalK;
            DepartureK = departureK;
        }

    }
}
