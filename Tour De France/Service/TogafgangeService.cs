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

        public IEnumerable<Togafgang> SortByArrivalK()
        {
            return from item in togafganges
                   orderby item.ArrivalK
                   select item;
        }

        public IEnumerable<Togafgang> SortByArrivalKDescending()
        {
            return from item in togafganges
                   orderby item.ArrivalK descending
                   select item;
        }
        public IEnumerable<Togafgang> SortByArrivalN()
        {
            return from item in togafganges
                orderby item.ArrivalN
                select item;
        }

        public IEnumerable<Togafgang> SortByArrivalNDescending()
        {
            return from item in togafganges
                orderby item.ArrivalN descending
                select item;
        }
    }
}
