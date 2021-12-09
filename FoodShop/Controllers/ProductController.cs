using FoodShop.Models;
using FoodShopModel.Constants;
using FoodShopModel.Products;
using FoodShopServiceAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAPI _productAPI;
        private readonly ICategoryAPI _categoryAPI;
        private readonly ISlideAPI _slideAPI;
        public ProductController ( IProductAPI productAPI , ICategoryAPI categoryAPI, ISlideAPI slideAPI )
        {
            _productAPI = productAPI;
            _categoryAPI = categoryAPI;
            _slideAPI = slideAPI;
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
        public async Task<IActionResult> NewProduct()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var viewModel = new NewProductViewModel
            {
                Slides = await _slideAPI.GetAll(),
                LatestProducts = await _productAPI.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts),
            };

            return View(viewModel);
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
