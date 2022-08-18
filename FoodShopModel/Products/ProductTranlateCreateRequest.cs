using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FoodShopModel.Products
{
    public class ProductTranlateCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        
    }
}
