using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MariosFoods.Models;

namespace MariosFoods.Tests
{
    [TestClass]
    public class ReviewTest
    {
        [TestMethod]
        public void GetPropertiesTest()
        {
            var review = new Review("Ellie", "This is some content from Ellie", 3, 1);

            var authorResult = review.Author;
            var contentBodyResult = review.ContentBody;
            var ratingResult = review.Rating;
            var productIdResult = review.ProductId;


            Assert.AreEqual("Ellie", authorResult);
            Assert.AreEqual("This is some content from Ellie", contentBodyResult);
            Assert.AreEqual(3, ratingResult);
            Assert.AreEqual(1, productIdResult);

        }

        [TestMethod]
        public void GetProductPropsTest()
        {
            var product = new Product("Chips", 2.00, "USA");

            var nameResult = product.Name;
            var costResult = product.Cost;
            var originResult = product.Origin;

            Assert.AreEqual("Chips", nameResult);
            Assert.AreEqual(2.00, costResult);
            Assert.AreEqual("USA", originResult);
        }
    }
}
