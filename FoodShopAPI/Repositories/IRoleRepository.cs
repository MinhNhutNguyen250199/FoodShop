using FoodShopModel.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
    public interface IRoleRepository
    {
        Task<List<RolesViewModel>> GetAll();
    }
}
