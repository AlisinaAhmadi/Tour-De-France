using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class TogafgangService
    {
        private List<Togafgang> togafganges;

        public DbGenericService<Togafgang> DbService { get; set; }

        public TogafgangService(DbGenericService<Togafgang> dbService)
        {
            DbService = dbService;
            togafganges = dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddTogafgange(Togafgang togafgang)
        {
            togafganges.Add(togafgang);
            await DbService.AddObjectAsync(togafgang);
        }

        public IEnumerable<Togafgang> GetTogafgange()
        {
            return togafganges;
        }

        public Togafgang GetTogafgang(int id)
        {
            foreach (var togafgang in togafganges)
            {
                if (togafgang.TogafgangId == id)
                {
                    return togafgang;
                }
            }

            return null;
        }

        public IEnumerable<Togafgang> SortByArrival()
        {
            return from item in togafganges
                   orderby item.Arrival
                   select item;
        }

        public IEnumerable<Togafgang> SortByArrivalDescending()
        {
            return from item in togafganges
                   orderby item.Arrival descending
                   select item;
        }


        public IEnumerable<Togafgang> SortByDeparture()
        {
            return from item in togafganges
                orderby item.Departure
                select item;
        }

        public IEnumerable<Togafgang> SortByDepartureDescending()
        {
            return from item in togafganges
                orderby item.Departure descending
                select item;
        }

        public async Task DeleteTogafgange(int togafgangId)
        {
            Togafgang itemToBeDeleted = togafganges.Find(togafgang => togafgang.TogafgangId == togafgangId);
            if (itemToBeDeleted != null)
            {
                togafganges.Remove(itemToBeDeleted);
                await DbService.DeleteObjectAsync(itemToBeDeleted);
            }
        }


        public async Task EditTogafgange(Togafgang togafgang)
        {
            if (togafgang != null)
            {
                foreach (var t in togafganges)
                {
                    if (t.TogafgangId == togafgang.TogafgangId)
                    {
                        t.Departure = togafgang.Departure;
                        t.Arrival = togafgang.Arrival;
                    }
                }
                await DbService.UpdateObjectAsync(togafgang);
            }
        }
    }
}
