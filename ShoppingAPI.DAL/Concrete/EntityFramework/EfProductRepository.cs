﻿using Microsoft.EntityFrameworkCore;
using ShoppingAPI.DAL.Abstract;
using ShoppingAPI.DAL.Concrete.EntityFramework.DataManagement;
using ShoppingAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.DAL.Concrete.EntityFramework
{
    public class EfProductRepository : EfRepository<Product>, IProductRepository
    {
        public EfProductRepository(DbContext context) : base(context)
        {
        }
    }
}
