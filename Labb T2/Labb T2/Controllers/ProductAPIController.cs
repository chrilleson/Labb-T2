using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb_T2.Models;

namespace Labb_T2.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductAPI")]
    public class ProductAPIController : Controller
    {
        private readonly IApiRequestSend<Product> ApiRequestSend;

        public ProductAPIController(IApiRequestSend<Product> apiRequestSend)
        {
            ApiRequestSend = apiRequestSend;
        }

        public void AddProduct(Product product)
        {
            ApiRequestSend.AddEntity(product);
        }

        public void EditProduct(int id, Product product)
        {
            ApiRequestSend.ModifyEntity(id, product);
        }

        public void DeleteProduct(Product product)
        {
            ApiRequestSend.DeleteEntity(product);
        }

        public void GetAllData() => ApiRequestSend.GetAllData();
    }
}