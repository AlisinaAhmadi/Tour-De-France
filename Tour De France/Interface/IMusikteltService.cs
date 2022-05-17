using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Interface
{

    interface IMusikteltRepositoryService
    {
        IEnumerable<Musiktelt> GetMusiktelt();
        void AddMusktelt(Musiktelt musiktelt);

        IEnumerable<Musiktelt> BandFilter(string str);

        IEnumerable<Musiktelt> PriceFilter(int maxPrice, int minPrice = 0);
    }
}
