using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    //public class DeltagerDbService : DbGenericService<Deltager>
    //{
    //    public async Task<Deltager> GetOrdersByDeltagerIdAsync(int id)
    //    {
    //        Deltager deltager;

    //        using (var context = new EventDbContext())
    //        {
    //            deltager = context.Deltagere
    //                .Include(u => u.Orders)
    //                .ThenInclude(i => i.Item)
    //                .AsNoTracking()
    //                .FirstOrDefault(u => u.UserId == id);
    //        }

    //        return user;
    //    }
    //}
}
