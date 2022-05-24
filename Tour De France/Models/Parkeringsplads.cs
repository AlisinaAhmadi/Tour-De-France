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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]


        [Range(typeof(int), "0", "90", ErrorMessage = "ID Skal være imellem {1} og {2}")]
        public int ppId { get; set; }

        [Required]
        [Range(typeof(int), "1", "1", ErrorMessage = "Du kan kun booke én parkeringsplads")]
        public int Count { get; set; }

        public bool Free { get; set; }

        public Parking_plads()
        {

        }

        public Parking_plads(int ppid, int count, bool free)
        {
            ppId = ppid;
            Count = count;
            Free = free;
        }
    }
}
