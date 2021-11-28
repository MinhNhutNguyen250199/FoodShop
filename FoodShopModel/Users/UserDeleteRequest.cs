using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShopModel.Users
{
    public class UserDeleteRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

