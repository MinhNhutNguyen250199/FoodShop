using FoodShopModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Models
{
    public class NewProductViewModel
    {
        public List<SlideViewModel> Slides { get; set; }
        public List<ProductViewModel> LatestProducts { get; set; }
    }
}
