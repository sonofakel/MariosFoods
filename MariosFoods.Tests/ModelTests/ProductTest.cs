using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MariosFoods.Models;

namespace MariosFoods.Tests
{
    [TestClass]
    public class ProductTest
    {
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

        //[TestMethod]
        //public void GetReviewAverageByProduct()
        //{
        //    Review testReview = new Review("Ellie", "This is a review by Ellie", 3, 1);
        //    Review testReview1 = new Review("David", "This is a review by David", 5, 1);

        //    Review.Save(testReview);
        //    Review.Save(testReview1);



        //    int expected = 4;

        //    Assert.AreEqual(expected,);


        //}

    }


}