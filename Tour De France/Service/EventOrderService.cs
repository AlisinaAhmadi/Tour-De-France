using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class EventOrderService
    {
        private List<EventOrder> EventOrderList { get; set; }
        public DbGenericService<EventOrder> DbService { get; set; }
        public EventOrderService(DbGenericService<EventOrder> dbService)
        {
            DbService = dbService;
            EventOrderList = DbService.GetObjectsAsync().Result.ToList();
        }

        public async void AddEventOrder(EventOrder eventOrder)
        {
            EventOrderList.Add(eventOrder);
            await DbService.AddObjectAsync(eventOrder);
        }
    }
}
