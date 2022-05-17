using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Mockdata
{

    public class MockSpistelt
    {
        private static List<Spisetelt> spisetelts = new List<Spisetelt>()
        {
            new Spisetelt(12,"post","cola",50),
        };




        public static List<Spisetelt> GetmockSpisetelts ()
        {
            return spisetelts; }

    }
}
