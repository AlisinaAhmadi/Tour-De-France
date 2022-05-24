using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tour_De_France.Models;


namespace Tour_De_France.Service
{
    public class DeltagerDbService : DbGenericService<Deltager>
    {
        public async Task<Deltager> GetOrdersByDeltagerIdAsync(int id)
        {
            Deltager deltager;

            await using (var context = new EventDbContext())
            {
                deltager = context.Deltagere
                    .Include(u => u.Orders)
                    .ThenInclude(i => i.VIP)
                    .AsNoTracking()
                    .FirstOrDefault(u => u.DeltagerId == id);
            }

            return deltager;
        }
    }
}
