using FoodShop.Models;
using FoodShopModel.Products;
using FoodShopServiceAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAPI _productAPI;
        private readonly ICategoryAPI _categoryAPI;
        public ProductController ( IProductAPI productAPI , ICategoryAPI categoryAPI )
        {
            _productAPI = productAPI;
            _categoryAPI = categoryAPI;
        }

        public async Task<IActionResult> Category(int id, string culture, int page = 1)
        {
            var products = await _productAPI.GetPagings(new GetManageProductPagingRequest()
            {
                CategoryId = id,
                PageIndex = page,
                LanguageId = culture,
                PageSize = 10
            });
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryAPI.GetById(culture, id),
                Products = products
            }); ;
        }

        public async Task<IActionResult> Detail(int id, string culture)
        {
            
            var product = await _productAPI.GetById(id, culture);
            return View(new ProductDetailViewModel()
            {
                Product = product,
                Category = await _categoryAPI.GetById(culture, id)
            });
        }
    }
}
