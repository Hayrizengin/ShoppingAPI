﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingAPI.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using ShoppingAPI.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAPI.DAL.Concrete.EntityFramework.Mapping
{
    public class OrderDetailMap:BaseMap<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasOne(q=>q.Order).WithMany(q=>q.OrderDetails).HasForeignKey(q=>q.OrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(q=>q.Product).WithMany(q=>q.OrderDetails).HasForeignKey(q=>q.ProductId).OnDelete(DeleteBehavior.Cascade);           
        }
    }
}
