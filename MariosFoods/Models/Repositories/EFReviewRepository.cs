using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariosFoods.Models.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        MariosFoodsContext db = new MariosFoodsContext();

        public EFReviewRepository(MariosFoodsContext connection = null)
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

        public IQueryable<Review> Reviews
        { get { return db.Reviews; } }

        public IQueryable<Product> Products
        { get { return db.Products; } }

        public Review Save(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
            return review;
        }

        public Review Edit(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
            return review;
        }

        public void Remove(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

        public void RemoveAll()
        {
            db.Reviews.RemoveRange(db.Reviews.ToList());
            db.SaveChanges();
        }
    }
}
