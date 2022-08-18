using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShopModel.Categories
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
