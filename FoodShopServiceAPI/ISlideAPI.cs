using FoodShopModel.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopServiceAPI
{
    public interface ISlideAPI
    {
        Task<List<SlideViewModel>> GetAll();

    }
}
