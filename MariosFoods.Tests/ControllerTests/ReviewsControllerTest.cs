using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MariosFoods.Models;
using MariosFoods.Models.Repositories;
using MariosFoods.Controllers;
using Moq;
using System.Linq;
using System;


namespace MariosFoods.Tests.ControllerTests
{
    [TestClass]
    public class ReviewsControllerTest : IDisposable
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();
        EFReviewRepository db = new EFReviewRepository(new TestDbContext());
        EFProductRepository db2 = new EFProductRepository(new TestDbContext());

        public void Dispose()
        {
            db.RemoveAll();
            db2.RemoveAll();
        }

        private void DbSetup()
        {
            mock.Setup(mock => mock.Reviews).Returns(new Review[]
            {
                new Review {ReviewId = 1, Author = "Ellie", ContentBody = "This is some content from Ellie", Rating = 3, ProductId = 1},
                new Review {ReviewId = 2, Author = "Allie", ContentBody = "This is some content from Allie", Rating = 4, ProductId = 2},
                new Review {ReviewId = 3, Author = "George", ContentBody = "This is some content from George", Rating = 5, ProductId = 1},
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_Test() //confirms route returns view
        {
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexListOfReviews_Test()
        {
            DbSetup();
            ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsInstanceOfType(result, typeof(List<Review>));
        }

        [TestMethod]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review testReview = new Review();
            testReview.ReviewId = 1;
            testReview.Author = "Ellie";
            testReview.ContentBody = "This is some content from Ellie";
            testReview.Rating = 3;
            testReview.ProductId = 1;

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Review>;

            CollectionAssert.Contains(collection, testReview);
        }
        [TestMethod]
        public void DB_CreateNewEntry_test()
        {
            ReviewsController controller = new ReviewsController(db);
            ProductsController controller1 = new ProductsController(db2);
            Product testproduct = new Product("Chips", 2.00 ,"USA");
            testproduct.ProductId = 1;
            Review testReview = new Review();
            testReview.ReviewId = 1;
            testReview.Author = "Ellie";
            testReview.ContentBody = "This is some content from Ellie";
            testReview.Rating = 3;
            testReview.ProductId = 1;

            controller1.Create(testproduct);

            controller.Create(testReview);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

            CollectionAssert.Contains(collection, testReview);
        }

        [TestMethod]
        public void DB_Edit_test()
        {
            ReviewsController reviewController = new ReviewsController(db);
            ProductsController productController = new ProductsController(db2);
            Product testproduct = new Product("Chips", 2.00, "USA");
            testproduct.ProductId = 1;
            Review testReview = new Review();
            testReview.ReviewId = 1;
            testReview.Author = "Ellie";
            testReview.ContentBody = "This is some content from Ellie";
            testReview.Rating = 3;
            testReview.ProductId = 1;

            productController.Create(testproduct);
            reviewController.Create(testReview);

            testReview.Author = "Eli";
            reviewController.Edit(testReview);

            var collection = (reviewController.Index() as ViewResult).ViewData.Model as List<Review>;

            Assert.AreEqual(testReview.Author, "Eli");
        }
    }
}
