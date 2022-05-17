using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Interface
{

    interface ISpisteltRepositoryService
    {
        IEnumerable<Spisetelt> getSpisetelts();
        void AddSpisetelt(Spisetelt spisetelt);

        IEnumerable<Spisetelt> FoodFilter(string str);

        IEnumerable<Spisetelt> PriceFilter(int maxPrice, int minPrice = 0);
    }
}
