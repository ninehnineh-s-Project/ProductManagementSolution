﻿using BusinessObject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> Exists(int id);
    }
}
