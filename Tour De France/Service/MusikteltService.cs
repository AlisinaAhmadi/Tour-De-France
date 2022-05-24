using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class MusikteltService
    {

        private List<Musiktelt> musiktelts;

        public DbGenericService<Musiktelt> DbService { get; set; }

        public MusikteltService(DbGenericService<Musiktelt> dbService)
        {
            DbService = dbService;
            musiktelts= dbService.GetObjectsAsync().Result.ToList();
        }

        public async Task AddMusiktel(Musiktelt musiktelt)
        {
            musiktelts.Add(musiktelt);
            await DbService.AddObjectAsync(musiktelt);
        }


        public IEnumerable<Musiktelt> GetMusiktelts()
        {
            return musiktelts;  
        }



        public IEnumerable<Musiktelt> SortByTime()
        {
            return from item in musiktelts
                   orderby item.Time
                   select item;
        }



        public IEnumerable<Musiktelt> SortByBand()
        {
            return from item in musiktelts
                   orderby item.Band descending
                   select item;
        }
        public IEnumerable<Musiktelt> SortByDrinks()
        {
            return from item in musiktelts
                   orderby item.Drinks
                   select item;
        }

        public IEnumerable<Musiktelt> SortByPrice()
        {
            return from item in musiktelts
                   orderby item.Price descending
                   select item;
        }



        public Musiktelt GetMusiktelt(int Mid)
        {
            foreach (Musiktelt musiktelt in musiktelts)
            {
                if (musiktelt.Mid == Mid) return musiktelt;
            }
            return null;
        }

        public void UpdateMusiktelt(Musiktelt musiktelt)
        {
            if (musiktelt != null)
            {
                foreach (Musiktelt i in musiktelts)
                {
                    if (i.Mid == musiktelt.Mid)
                    {
                        i.Mid = musiktelt.Mid;
                        i.Price = musiktelt.Price;
                        i.Band = musiktelt.Band;
                        i.Drinks = musiktelt.Drinks;
                        i.Time = musiktelt.Time;
                    }
                }

                DbService.UpdateObjectAsync(musiktelt);
            }
        }

        public Musiktelt DeleteMusiktelt(int musiteltMid)
        {
            Musiktelt musikteltToBeDeleted = musiktelts.Find(musiktelt => musiktelt.Mid == musiteltMid);
            
            if (musikteltToBeDeleted != null)
            {
                musiktelts.Remove(musikteltToBeDeleted);
                DbService.DeleteObjectAsync(musikteltToBeDeleted);
            }
            return musikteltToBeDeleted;
        }

        public IEnumerable<Musiktelt> TimeSearch(string str)
        {
            List<Musiktelt> nameSearch = new List<Musiktelt>();
            foreach (Musiktelt item in musiktelts)
            {
                if (item.Band.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                    
                }
            }

            return nameSearch;
        }
        public IEnumerable<Musiktelt> NameSearch(string str)
        {
            if (string.IsNullOrEmpty(str)) return musiktelts;
            return musiktelts.FindAll(musiktelts => musiktelts.Band.ToLower().Contains(str.ToLower()));
        }

      

        public IEnumerable<Musiktelt> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Musiktelt> filterList = new List<Musiktelt>();
            foreach (Musiktelt musiktelt in musiktelts)
            {
                if ((minPrice == 0 && musiktelt.Price <= maxPrice) || (maxPrice == 0 && musiktelt.Price >= minPrice) || (musiktelt.Price >= minPrice && musiktelt.Price <= maxPrice))
                {
                    filterList.Add(musiktelt);
                }
            }

            return filterList;
        }



    }



}
