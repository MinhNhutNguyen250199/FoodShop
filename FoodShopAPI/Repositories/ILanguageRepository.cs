using FoodShopModel.Common;
using FoodShopModel.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
   public interface ILanguageRepository
    {
        Task<ApiResult<List<LanguagesViewModel>>> GetAll();
    }
}
