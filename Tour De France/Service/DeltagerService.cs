using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class DeltagerService
    {
        public List<Deltager> Deltagere { get; set; }

        public DbGenericService<Deltager> DbService { get; set; }

        public DeltagerService(DbGenericService<Deltager> dbService)
        {
            DbService = dbService;
            Deltagere = DbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddDeltager(Deltager deltager)
        {
            Deltagere.Add(deltager);
            await DbService.AddObjectAsync(deltager);
        }
    }
}
