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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Key]
        public int Time { get; set; }
        [Required]
        public string Food { get; set; }
        [Required]
        public string Drinks { get; set; }
        [Required]
        public double Price { get; set; }

        public Spisetelt()
        {
            
        }

        public Spisetelt(int time, string food, string drinks, int price)
        {
            Time = time;
            Food = food;
            Drinks = drinks;
            Price = price;
        }
    }
}
