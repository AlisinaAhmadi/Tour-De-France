using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Mockdata;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class EventService
    {
        private List<Event> evens;

        public EventService()
        {
            evens = MockEvenscs.GetmockEvens();

        }
        public void AddEven(Event even)
        {
            evens.Add(even);
        }

        public IEnumerable<Event> GetEvens()
        {
            return evens;
        }

        
    }
}
