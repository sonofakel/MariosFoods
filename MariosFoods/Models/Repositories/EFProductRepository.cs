﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariosFoods.Models.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        MariosFoodsContext db = new MariosFoodsContext();

        public EFProductRepository(MariosFoodsContext connection = null)
        {
            if (connection == null)
            {
                this.db = new MariosFoodsContext();
            }
            else
            {
                this.db = connection;
            }
        }

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public Product Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product;
        }

        public Product Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return product;
        }

        public void Remove(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void RemoveAll()
        {
            db.Products.RemoveRange(db.Products.ToList());
            db.SaveChanges();
        }
    }
}