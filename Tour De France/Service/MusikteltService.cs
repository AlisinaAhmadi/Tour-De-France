using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Mockdata;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class MusikteltService
    {
        private List<Musiktelt> musiktelts;
        private Musiktelt musiktelt;

        public MusikteltService()
        {
            musiktelts = MockMusiktelt.GetmocMusiktelts();

        }
        public void AddMusiktelt(Musiktelt musiktelt)
        {
            musiktelts.Add(musiktelt);
        }

        public IEnumerable<Musiktelt> GetEvens()
        {
            return musiktelts;
        }

        internal object GetMusiktelt()
        {
            throw new NotImplementedException();
        }
    }



}
