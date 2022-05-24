using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class SpiseteltService
    {


        private List<Spisetelt> spisetelts;
        private Spisetelt spisetelt;

        public SpiseteltService()
        {
            spisetelts = MockSpistelt.GetmockSpisetelts();

        }
        public void AddSpisetelt(Spisetelt spisetelt)
        {
            spisetelts.Add(spisetelt);
            await DbService.AddObjectAsync(spisetelt);
        }

        public IEnumerable<Spisetelt> GetSpisetelts()
        {
            return spisetelts;
        }

        public IEnumerable<Spisetelt> SortByTime()
        {
            return from item in spisetelts
                orderby item.Time
                select item;
        }


        public IEnumerable<Spisetelt> SortByFood()
        {
            return from item in spisetelts
                orderby item.Food descending
                select item;
        }

        public IEnumerable<Spisetelt> SortBYDrinks()
        {
            return from item in spisetelts
                orderby item.Drinks
                select item;
        }

        public IEnumerable<Spisetelt> SortByPrice()
        {
            return from item in spisetelts
                orderby item.Price descending
                select item;
        }
        

        public Spisetelt GetSpisetelt(int Sid)

        {
            foreach (Spisetelt item in spisetelts)
            {
                if (item.Sid == Sid) return item;
            }
            return null;
        }


        public void UpdateSpisetelt(Spisetelt spisetelt)
        {
            if (spisetelt != null)
            {
                foreach (Spisetelt i in spisetelts)
                {
                    if (i.Sid == spisetelt.Sid)
                    {
                        i.Sid = spisetelt.Sid;
                        i.Price = spisetelt.Price;
                        i.Food = spisetelt.Food;
                        i.Drinks = spisetelt.Drinks;
                        i.Time = spisetelt.Time;
                    }
                }

                DbService.UpdateObjectAsync(spisetelt);
            }
        }

        public Spisetelt DeleteSpisetelt(int Sid)
        {
            Spisetelt spiseteltToBeDeleted = spisetelts.Find(spisetelt => spisetelt.Sid == Sid);
            if (spiseteltToBeDeleted != null)
            {
                spisetelts.Remove(spiseteltToBeDeleted);
            }
            return spiseteltToBeDeleted;
        }


        public IEnumerable<Spisetelt> NameSearch(string str)
        {
            List<Spisetelt> nameSearch = new List<Spisetelt>();
            foreach (Spisetelt item in spisetelts)
            {
                if (item.Food.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(item);
                }
            }

            return nameSearch;
        }

        public IEnumerable<Spisetelt> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Spisetelt> filterList = new List<Spisetelt>();
            foreach (Spisetelt item in spisetelts)
            {
                if ((minPrice == 0 && item.Price <= maxPrice) || (maxPrice == 0 && item.Price >= minPrice) || (item.Price >= minPrice && item.Price <= maxPrice))
                {
                    filterList.Add(item);
                }
            }

            return filterList;
        }




    }



}
