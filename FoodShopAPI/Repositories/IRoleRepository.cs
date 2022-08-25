using FoodShopModel.Roles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
    public interface IRoleRepository
    {
        Task<List<RolesViewModel>> GetAll();
    }
}
