using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class Spisetelt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sid { get; set; }

        [Required]
        [Key]
        public int Sid { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required]
        public string Food { get; set; }
        [Required]
        public string Drinks { get; set; }

        [Required]
        public double Price { get; set; }

        public Spisetelt()
        {
            
        }

        public Spisetelt(DateTime time, string food, string drinks, int price)
        {
            Sid = sid;
            Time = time;
            Food = food;
            Drinks = drinks;
            Price = price;
        }

    }
}
