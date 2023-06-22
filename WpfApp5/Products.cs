using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    //[Name],[Description],[Price],[Discount],[Quantity]
    public class Products
    {
        public Products(string name, string description, int price, int discount, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Discount = discount;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }


    }
}
