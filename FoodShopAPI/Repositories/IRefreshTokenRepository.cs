using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
    public interface IRefreshTokenRepository
    {
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        JwtSecurityToken GenerateAccessToken(ClaimsPrincipal claimsPrincipal);
    }
}
