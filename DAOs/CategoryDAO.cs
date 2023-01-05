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
    public class CategoryDAO : GenericDAO<Category>
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new object();

        protected CategoryDAO() { }

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                    return instance;
                }
            }
        }
        
        //public async Task<IEnumerable<Category>> GetCategories()
        //{
        //    using(var context = new ProductManagementDbContext())
        //    {
        //        return await context.Categories.ToListAsync();
        //    }
        //}
    }
}
