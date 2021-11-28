using FoodShopModel.Common;
using FoodShopModel.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopServiceAPI
{
   public interface ILanguageAPI
    {
        Task<ApiResult<List<LanguagesViewModel>>> GetAll();
    }
}
