using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class OrderService
    {
        public DbGenericService<Order> DbService { get; set; }
        public List<Order> OrderList { get; set; }

        public OrderService(DbGenericService<Order> dbService)
        {
            DbService = dbService;
            OrderList = DbService.GetObjectsAsync().Result.ToList();
        }

        public async void AddOrder(Order order)
        {
            OrderList.Add(order);
            await DbService.AddObjectAsync(order);
        }
    }
}
