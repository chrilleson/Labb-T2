using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb_T2.Models
{
    public class Product
    {
        public Product(int id, int quantity, decimal price, string typeofproduct, string section)
        {
            id = Id;
            quantity = Quantity;
            price = Price;
            typeofproduct = TypeOfProduct;
            section = Section;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string TypeOfProduct { get; set; }
        public string Section { get; set; }
    }
}
