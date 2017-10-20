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
    public class ProductsControllerTest : IDisposable
    {
        Mock<IProductRepository> mock = new Mock<IProductRepository>();
        EFProductRepository db = new EFProductRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(mock => mock.Products).Returns(new Product[]
            {
                new Product {ProductId = 1, Name="Chips", Cost=2.00, Origin="USA"},
                new Product {ProductId = 2, Name="Soda", Cost=1.00, Origin="USA"}
            }.AsQueryable());
        }

        [TestMethod]
        public void DB_CreateNewEntry_test()
        {
            ProductsController controller = new ProductsController(db);
            Product testProduct = new Product();
            testProduct.Name = "Chips";
            testProduct.Cost = 2.00;
            testProduct.Origin = "USA";

            controller.Create(testProduct);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Product>;

            CollectionAssert.Contains(collection, testProduct);
        }

        public void Dispose()
        {
            db.RemoveAll();
        }

    }
}