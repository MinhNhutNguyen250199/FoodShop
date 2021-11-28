using FoodShopModel.Common;
using FoodShopModel.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodShopServiceAPI
{
    public class LanguageAPI : BaseAPI, ILanguageAPI
    {
        public LanguageAPI(IHttpClientFactory httpClientFactory,
                  IHttpContextAccessor httpContextAccessor,
                   IConfiguration configuration)
           : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }
        public async Task<ApiResult<List<LanguagesViewModel>>> GetAll()
        {
            return await GetAsync<ApiResult<List<LanguagesViewModel>>>("/api/Languages");
        }
    }
}
