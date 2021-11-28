using FoodShopModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
    public interface ISlideRepository
    {
        Task<List<SlideViewModel>> GetAll();
    }
}
