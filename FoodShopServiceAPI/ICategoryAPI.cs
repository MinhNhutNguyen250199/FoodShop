using FoodShopModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopServiceAPI
{
    public interface ICategoryAPI
    {
        Task<List<CategoryViewModel>> GetAll(string languageId);

        Task<CategoryViewModel> GetById(string languageId, Guid id);
    }
}
