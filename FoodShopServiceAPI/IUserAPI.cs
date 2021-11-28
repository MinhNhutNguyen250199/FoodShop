using FoodShopModel.Common;
using FoodShopModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopServiceAPI
{
    public interface IUserAPI
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);


        Task<ApiResult<bool>> UpdateUser(int id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPagings(GetUserPagingRequest request);



        Task<ApiResult<UserViewModel>> GetById(int id);

        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);
        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<bool>> RoleAssign(int id, RoleAssignRequest request);
    }
}

