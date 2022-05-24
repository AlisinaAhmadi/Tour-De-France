using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class ParkeringspladsService
    {
        public List<Parking_plads> Parkeringsplads;

        public DbGenericService<Parking_plads> DbService { get; set; }

        public ParkeringspladsService(DbGenericService<Parking_plads> dbService)
        {
            DbService = dbService;
            Parkeringsplads = dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddParkeringspladsAsync(Parking_plads parkeringsplads)
        {
            Parkeringsplads.Add(parkeringsplads);
            await DbService.AddObjectAsync(parkeringsplads);
        }


        public IEnumerable<Parking_plads> GetParkeringsplads()
        {
            return Parkeringsplads;
        }

        public Parking_plads GetParkingsplads(int id)
        {
            foreach (Parking_plads parkingPlads in Parkeringsplads)
            {
                if (parkingPlads.ppId == id) return parkingPlads;
            }
            return null;
        }

        public IEnumerable<Parking_plads> SortById()
        {
            return from item in Parkeringsplads
                   orderby item.ppId
                   select item;
        }

        public IEnumerable<Parking_plads> SortByIdDescending()
        {
            return from item in Parkeringsplads
                   orderby item.ppId descending
                   select item;
        }


        public async Task DeleteParkeringspladsAsync(int ppid)
        {
            Parking_plads parkeringspladsToBeDeleted = Parkeringsplads.Find(Parkeringsplads => Parkeringsplads.ppId == ppid);


            if (parkeringspladsToBeDeleted != null)
            {
                Parkeringsplads.Remove(parkeringspladsToBeDeleted);
                await DbService.DeleteObjectAsync(parkeringspladsToBeDeleted);
            }
        }


        public async Task UpdateParkeringspladsAsync(Parking_plads parkingPlads)
        {
            if (parkingPlads != null)
            {
                foreach (Parking_plads i in Parkeringsplads)
                {
                    if (i.ppId == parkingPlads.ppId)
                    {
                        i.Free = parkingPlads.Free;
                        i.Count = parkingPlads.Count;
                    }
                }
                await DbService.UpdateObjectAsync(parkingPlads);
            }
        }
    }
}
