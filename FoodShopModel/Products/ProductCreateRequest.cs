using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FoodShopModel.Products
{
    public class ProductCreateRequest
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public IFormFile ThumbnailImage { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string NameVN { set; get; }
        public string DescriptionVN { set; get; }
        public string DetailsVN { set; get; }
        public string SeoDescriptionVN { set; get; }
        public string SeoTitleVN { set; get; }

        public string SeoAliasVN { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string NameEN { set; get; }
        public string DescriptionEN { set; get; }
        public string DetailsEN { set; get; }
        public string SeoDescriptionEN { set; get; }
        public string SeoTitleEN { set; get; }

        public string SeoAliasEN { get; set; }

    }
}
