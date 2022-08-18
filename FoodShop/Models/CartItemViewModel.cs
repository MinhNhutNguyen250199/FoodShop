using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Models
{
    public class CartItemViewModel
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }  

        public string Image { get; set; }
    }
}
