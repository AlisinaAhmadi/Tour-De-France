using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Interface
{
    
    interface IEvenRepositoryService
    {
        IEnumerable<Event> GetEvens();
        void AddItem(Event even);

        IEnumerable<Event> NameFilter(int str);

        IEnumerable<Event> TimEvensFilter(int maxTime, int minTime = 0);
    }
}

