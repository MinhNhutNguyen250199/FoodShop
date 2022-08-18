using FoodShopModel.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
   public interface ICategoryRepository
    {

        Task<List<CategoryViewModel>> GetAll(string languageId);
        Task<CategoryViewModel> GetById(string languageId, Guid id);
    }
}
