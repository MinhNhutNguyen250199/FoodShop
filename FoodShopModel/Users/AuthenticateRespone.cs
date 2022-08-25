using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FoodShopModel.Users
{
    public class AuthenticateRespone
    {
        public string AccesToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
