using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class DeltagerService
    {
        public List<Deltager> Deltagere { get; set; }

        //public DbGenericService<Deltager> DbService { get; set; }
        public DeltagerDbService DbService { get; set; }

        public DeltagerService(DeltagerDbService dbService)
        {
            DbService = dbService;
            Deltagere = DbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddDeltager(Deltager deltager)
        {
            Deltagere.Add(deltager);
            await DbService.AddObjectAsync(deltager);
        }

        public Deltager GetDeltager(int id)
        {
            foreach (var deltager in Deltagere)
            {
                if (deltager.DeltagerId == id)
                {
                    return deltager;
                }
            }

            return null;
        }

        public async Task DeletePassword(string p)
        {
            Deltager passwordToBeDeleted = Deltagere.Find(deltager => deltager.Password == p);

            if (passwordToBeDeleted != null)
            {
                Deltagere.Remove(passwordToBeDeleted);
                await DbService.DeleteObjectAsync(passwordToBeDeleted);
            }
        }

        public async Task UpdatePasword(Deltager deltager)
        {
            if (deltager != null)
            {
                foreach (var p in Deltagere)
                {
                    if (p.DeltagerId == deltager.DeltagerId)
                    {
                        p.Password = deltager.Password;
                    }
                }
                await DbService.UpdateObjectAsync(deltager);
            }
        }

        public IEnumerable<Deltager> GetDeltagers()
        {
            return Deltagere;
        }

        public Deltager GetDeltagerByName(string name)
        {
            return Deltagere.Find(deltager => deltager.Name == name);
        }

        public async Task<Deltager> GetOrdersByDeltager(Deltager deltager)
        {
            return DbService.GetOrdersByDeltagerIdAsync(deltager.DeltagerId).Result;
        }
    }
}
