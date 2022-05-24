using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Mockdata;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{

    public class SpiseteltService
    {
        private List<Spisetelt> spisetelts;
        private Spisetelt spisetelt;

        //public SpiseteltService()
        //{
        //    spisetelts = MockSpistelt.GetmockSpisetelts();

        //}
        public void AddSpisetelt(Spisetelt spisetelt)
        {
            spisetelt.Add(spisetelt);
        }

        public IEnumerable<Spisetelt> GetSpisetelts()
        {
            return spisetelts;
        }


    }

}
