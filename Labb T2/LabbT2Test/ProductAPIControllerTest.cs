using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using Labb_T2.Controllers;
using Labb_T2.Models;

namespace LabbT2Test
{
    public class ProductAPIControllerTest
    {
        [Fact]
        public void ProductAPIController_TryingToGetAllDataIfEmpty_Success()
        {
            var mock = new Mock<IApiRequestSend<Product>>();
            var ProductAPIControllermock = new ProductAPIController(mock.Object);

            ProductAPIControllermock.GetAllData();
            mock.Verify(m => m.GetAllData(), Times.Once());
        }

        [Fact]
        public void ProductAPIController_TryingToGetAllDataFromList_Success()
        {
            var mock = new Mock<IApiRequestSend<Product>>();
            IEnumerable<Product> products = new[]
            {
                new Product()
                {
                    Id=1,
                    ProductName = "Sweden National Football Team, Home shirt WC2018",
                    Price = 899,
                    Quantity = 1000,
                    Section ="Clothes Section"

                },
                new Product()
                {
                    Id = 2,
                    ProductName = "Acer Predator Orion 9000",
                    Price = 30990,
                    Quantity = 500,
                    Section = "PC Section"
                },
                new Product()
                {
                    Id = 3,
                    ProductName = "Lamborghini Veneno Roadster",
                    Price = 4500000,
                    Quantity = 5,
                    Section = "Car Section"
                }
            };

            var ProductAPIControllerMock = new ProductAPIController(mock.Object);
            mock.Setup(m => m.GetAllData()).Returns(products);

            var actualObjects = mock.Object.GetAllData();
            var expectedObjects = products;

            Assert.Equal(expectedObjects, actualObjects);

        }

        [Fact]
        public void ProductAPIController_TryAddEntity_Sucess()
        {
            var product = GetProduct();
            var mock = new Mock<IApiRequestSend<Product>>();
            var ProductAPIControllerMock = new ProductAPIController(mock.Object);

            ProductAPIControllerMock.AddProduct(product);
            mock.Verify(m => m.AddEntity(product), Times.Once);
        }

        [Fact]
        public void ProductAPIController_TryEditEntity_Success()
        {
            var product = GetProduct();
            var mock = new Mock<IApiRequestSend<Product>>();
            var ProductAPIControllerMock = new ProductAPIController(mock.Object);

            ProductAPIControllerMock.EditProduct(product.Id, product);
            mock.Verify(m => m.ModifyEntity(product.Id, product), Times.Once);
        }

        [Fact]
        public void ProductAPIController_TryDeleteEntity_Success()
        {
            var product = GetProduct();
            var mock = new Mock<IApiRequestSend<Product>>();
            var ProductAPIControllerMock = new ProductAPIController(mock.Object);

            ProductAPIControllerMock.DeleteProduct(product);
            mock.Verify(m => m.DeleteEntity(product), Times.Once);
        }


        public Product GetProduct()
        {
            return new Product()
            {
                Id = 5,
                ProductName = "Cap",
                Price = 5000,
                Quantity = 10,
                Section = "Clothes Section"
            };
        }
    }
}
