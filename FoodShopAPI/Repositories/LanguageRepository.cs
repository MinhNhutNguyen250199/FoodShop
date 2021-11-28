using FoodShopData.EFContext;
using FoodShopModel.Common;
using FoodShopModel.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {

        private readonly IConfiguration _config;
        private readonly FoodShopDbContext _context;

        public LanguageRepository(FoodShopDbContext context,
            IConfiguration config)
        {
            _config = config;
            _context = context;
        }
        public async Task<ApiResult<List<LanguagesViewModel>>> GetAll()
        {
            var languages = await _context.Languages.Select(x => new LanguagesViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                IsDefault = x.IsDefault
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguagesViewModel>>(languages);
        }
    }
}
