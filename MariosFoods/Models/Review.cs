using System;

namespace MariosFoods.Models
{
    public class Review
    {
        public int ReviewId
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public string ContentBody
        {
            get;
            set;
        }
        public int Rating
        {
            get;
            set;
        }

        public int ProductId
        {
            get;
            set;
        }
        public virtual Product Product
        {
            get;
            set;
        }

        public override bool Equals(System.Object otherReview)
        {
            if (!(otherReview is Review))
            {
                return false;
            }
            else
            {
                Review newReview = (Review)otherReview;
                return this.ReviewId.Equals(newReview.ReviewId);
            }
        }

        public override int GetHashCode()
        {
            return this.ReviewId.GetHashCode();
        }

        public Review() { }

        public Review(string author, string contentBody, int rating, int productId)
        {
            this.Author = author;
            this.ContentBody = contentBody;
            this.Rating = rating;
            this.ProductId = productId;
        }

    }
}
