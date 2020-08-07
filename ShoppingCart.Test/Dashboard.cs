using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.API.Controllers;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Test
{
    [TestClass]
    public class Dashboard
    {
        [TestMethod]
        public void CategoryReturnsListObjects()
        {
            var category = new List<Category>() { new Category { CategoryId = 1, CategoryName = "Category" } };

            var repo = new Mock<ICategoryRepository>();

            //Act
            var controller = new CategoryController(repo.Object);
            repo.Setup(x => x.GetAll()).Returns(category);
            var result = controller.Get();

            //Assert
            Assert.IsTrue(result.Value.Count() > 0);
        }

        [TestMethod]
        public void ProductReturnsListObjects()
        {
            var product = new List<Product>() { new Product {
                ProductId = 1,
                Description = "Description",
                CategoryId = 1,
                Price = 12,
                ProductName = "Product",
                Url = "" } };

            var repo = new Mock<IProductRepository>();

            //Act
            var controller = new ProductController(repo.Object);
            repo.Setup(x => x.GetAll()).Returns(product);
            var result = controller.Get();

            //Assert
            Assert.IsTrue(result.Value.Count() > 0);
        }

        [TestMethod]
        public void ProductsReturnsListObjects()
        {
            var product = new List<Product>() { new Product {
                ProductId = 1,
                Description = "Description",
                CategoryId = 2,
                Price = 12,
                ProductName = "Product",
                Url = "" } };

            var repo = new Mock<IProductRepository>();

            //Act
            var controller = new ProductController(repo.Object);
            repo.Setup(x => x.GetProductsByCategoryId(2)).Returns(product);
            var result = controller.GetProductsByCategoryId("2");

            //Assert
            Assert.IsTrue(result.Value.Count() > 0);
        }
    }
}
