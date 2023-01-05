using BusinessObject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class GenericDAO<T> where T : class
    {
        private static GenericDAO<T> instance = null;
        private static readonly object instanceLock = new object();

        protected GenericDAO() { }

        public static GenericDAO<T> Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new GenericDAO<T>();
                    }
                    return instance;
                }
            }
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            using (var context = new ProductManagementDbContext())
            {
                return await context.Set<T>().ToListAsync();
            }
        }

        public virtual async Task<T> Get(int id)
        {
            using (var context = new ProductManagementDbContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task Add(T entity)
        {
            using (var context = new ProductManagementDbContext())
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(T entity)
        {
            using (var context = new ProductManagementDbContext())
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(T entity)
        {
            using (var context = new ProductManagementDbContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
