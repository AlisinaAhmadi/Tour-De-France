using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class EventOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventOrderId { get; set; }
        public int Count { get; set; }
        [Required]
        [Range(Int32.MaxValue, 3, ErrorMessage = "Eventet er desværre fyldt")]
        public int DeltagerId { get; set; }
        public Deltager Deltager { get; set; }
        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }

        public EventOrder(Deltager deltager, Event eEvent)
        {
            Deltager = deltager;
            Event = eEvent;
        }

        public EventOrder()
        {

        }
    }
}
