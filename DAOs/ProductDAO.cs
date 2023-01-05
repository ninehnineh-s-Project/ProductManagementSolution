using BusinessObject.Data;
using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class ProductDAO : GenericDAO<Product>
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        protected ProductDAO() { }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public async override Task<Product> Get(int id)
        {
            using (var context = new ProductManagementDbContext())
            {
                return await context.Products
                    .Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
        }

    }
}
