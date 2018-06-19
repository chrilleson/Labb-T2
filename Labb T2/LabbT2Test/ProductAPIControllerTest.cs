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
            mock.Verify(m => m.EditEntity(product.Id, product), Times.Once);
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
