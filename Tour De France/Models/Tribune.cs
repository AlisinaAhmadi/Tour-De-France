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
        public int TribuneId { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{dd-mm-yyyy}")]
        public DateTime Time { get; set; }

        public Tribune()
        {
                
        }

        public Tribune(int tribuneId, DateTime time)
        {
            TribuneId = tribuneId;
            Time = time;
        }
    }
}
