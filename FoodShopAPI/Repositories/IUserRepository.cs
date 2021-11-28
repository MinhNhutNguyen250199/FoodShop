using FoodShopData.Entities;
using FoodShopModel.Common;
using FoodShopModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repository
{
    public interface IUserRepository
    {
        //Task<List<User>> GetUserList();
        Task<ApiResult<string>> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(int id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<UserViewModel>> GetById(int id);

        Task<List<User>> GetUserList();
        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> RoleAssign(int id, RoleAssignRequest request);


    }
}
