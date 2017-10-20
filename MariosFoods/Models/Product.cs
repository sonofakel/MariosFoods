using System;
namespace MariosFoods.Models
{
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
