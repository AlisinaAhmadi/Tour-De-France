using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Mockdata
{
    public class MockEvenscs
    {
        private static List<Event> evens = new List<Event>()
        {
            new Event(8,"zealand Roskilde",100,71501730,"zealand@yahoo.com",1),
        };

        public static List<Event> GetmockEvens()
        {
            return evens;
        }

    }
}
