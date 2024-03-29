﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tour_De_France.Models
{
    public class Musiktelt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Mid { get; set; }
        [Required]
       
        public DateTime Time { get; set; }
        [Required]
        public string Band { get; set; }
        [Required]
        public string Drinks { get; set; }
        [Required]
        public double Price { get; set; }

        public Musiktelt()
        {
            
        }


        public Musiktelt(DateTime time, string band, string drinks, int price)
        {
            Time = time;
            Band = band;
            Drinks = drinks;
            Price = price;
        }
         
     
         

    }
}
