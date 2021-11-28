using FoodShopModel.Common;
using FoodShopModel.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopServiceAPI
{
    public interface IRoleAPI
    {
        Task<ApiResult<List<RolesViewModel>>> GetAll();
    }
}
