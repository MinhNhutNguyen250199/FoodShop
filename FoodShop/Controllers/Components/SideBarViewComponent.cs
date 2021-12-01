using FoodShopServiceAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShop.Controllers.Components
{
    public class SideBarViewComponent:ViewComponent 
    {
        private readonly ICategoryAPI _categoryAPI;

        public SideBarViewComponent(ICategoryAPI categoryAPI)
        {
            _categoryAPI = categoryAPI;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categoryAPI.GetAll(CultureInfo.CurrentCulture.Name);
            return View(items);
        }
    }
}
