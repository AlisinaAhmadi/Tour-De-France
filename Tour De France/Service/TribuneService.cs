using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class TribuneService
    {
        private List<Tribune> tribunes;
        public DbGenericService<Tribune> DbService { get; set; }

        public TribuneService(DbGenericService<Tribune> dbService)
        {
            DbService = dbService;
            tribunes = dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddTribune(Tribune tribune)
        {
            tribunes.Add(tribune);
            await DbService.AddObjectAsync(tribune);
        }

        public IEnumerable<Tribune> GetTribunes()
        {
            return tribunes;
        }

        public Tribune GetTribune(int id)
        {
            foreach (var tribune in tribunes)
            {
                if (tribune.TribuneId == id) return tribune;
            }
            return null;
        }

        public async Task DeleteTribune(int TribuneId)
        {
            Tribune tribuneToBeDeleted = tribunes.Find(tribune => tribune.TribuneId == TribuneId);
            if (tribuneToBeDeleted != null)
            {
                tribunes.Remove(tribuneToBeDeleted);
                await DbService.DeleteObjectAsync(tribuneToBeDeleted);
            }
        }

        public async Task EditTribune(Tribune tribune)
        {
            if (tribune != null)
            {
                foreach (var t in tribunes)
                {
                    if (t.Time == tribune.Time)
                    {
                        t.Time = tribune.Time;
                    }
                }
                await DbService.UpdateObjectAsync(tribune);
            }
        }
    }
}
