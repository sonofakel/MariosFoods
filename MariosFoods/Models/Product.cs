using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MariosFoods.Models.Repositories;


namespace MariosFoods.Models
{
    [Table("Product")]
    public class Product
    {

        public int ProductId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public double Cost
        {
            get;
            set;
        }

        public string Origin
        {
            get;
            set;
        }

        public virtual ApplicationUser User { get; set; }
       

        public ICollection<Review> Reviews { get; set; }

        public static List<Product> GetProducts()
        {
            MariosFoodsContext context = new MariosFoodsContext();
            var productList = context.Products.ToList();

            return productList;
        }

        public static decimal AverageRating(Product product)
        {
            var reviewList = product.Reviews;

            decimal sumReviews = 0;
            decimal averageRounded = 0;

            foreach(var review in reviewList)
            {
                sumReviews += review.Rating;
                decimal average = sumReviews / reviewList.Count;
                averageRounded = Math.Round(average, 2);
            }

            return averageRounded; 
        }

        public override bool Equals(System.Object otherProduct)
        {
            if (!(otherProduct is Product))
            {
                return false;
            }
            else
            {
                Product newProduct = (Product)otherProduct;
                return this.ProductId.Equals(newProduct.ProductId);
            }
        }

        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }

        public Product() { }

        public Product(string name, double cost, string origin)
        {
            this.Name = name;
            this.Cost = cost;
            this.Origin = origin;
        }
    }
}
