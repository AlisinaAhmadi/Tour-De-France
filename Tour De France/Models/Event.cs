using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        public string Titel { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{dd-mm-yyyy}")]
        public DateTime Time { get; set; }
        [Required(ErrorMessage = "Feltet må ikke være tomt!")]
        public string Address { get; set; }
    

        public Event()
        {

        }
        public Event(int eventId, string titel, string description, DateTime time, string address)
        {
            EventId = eventId;
            Titel = titel;
            Description = description;
            Time = time;
            Address = address;
        }
    }
}
