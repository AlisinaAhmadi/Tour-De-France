using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class Parking_plads
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public bool Free { get; set; }

        public Parking_plads()
        {
            
        }

        public Parking_plads(int id, bool free)
        {
            Id = id;
            Free = free;
        }
    }
}
