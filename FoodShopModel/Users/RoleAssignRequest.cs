using FoodShopModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShopModel.Users
{
    public class RoleAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}
