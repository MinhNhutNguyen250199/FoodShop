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


        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPagings(GetUserPagingRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> RegisterAdminUser(RegisterRequest registerRequest);

        Task<ApiResult<bool>> RegisterCustomerUser(RegisterRequest registerRequest);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}

