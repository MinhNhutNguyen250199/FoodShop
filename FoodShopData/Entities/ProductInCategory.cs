using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopData.Entities
{
    public class ProductInCategory
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
