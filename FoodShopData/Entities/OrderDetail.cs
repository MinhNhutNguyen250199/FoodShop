using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopData.Entities
{
    public class OrderDetail
    {
        public Guid OrderId { set; get; }
        public Guid ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Order Order { get; set; }

        public Product Product { get; set; }

    }
}
