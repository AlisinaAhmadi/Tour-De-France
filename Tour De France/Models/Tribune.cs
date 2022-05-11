using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class Tribune
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tid { get; set; }
        [Required]
        public int Time { get; set; }
    }
}
