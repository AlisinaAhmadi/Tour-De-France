using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tour_De_France.Models;

namespace Tour_De_France.Service
{
    public class DbGenericService<T> : IService<T> where T : class
    {


        public async Task<IEnumerable<T>> GetObjectsAsync()
        {
            using (var context = new EventDbContext())
            {
                return await context.Set<T>().AsNoTracking().ToListAsync();
            }

        }

        public async Task AddObjectAsync(T obj)
        {
            await using (var context = new EventDbContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }

        public async Task DeleteObjectAsync(T obj)
        {
            using (var context = new EventDbContext())
            {
                context.Set<T>().Remove(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateObjectAsync(T obj)
        {
            using (var context = new EventDbContext())
            {
                context.Set<T>().Update(obj);
                await context.SaveChangesAsync();
            }
        }

        public async Task<T> GetObjectByIdAsync(int id)
        {
            using (var context = new EventDbContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }
    }
}
