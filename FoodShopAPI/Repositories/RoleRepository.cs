using FoodShopData.Entities;
using FoodShopModel.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
    public class RoleRepository : IRoleRepository
    {

        private readonly RoleManager<Role> _roleManager;

        public RoleRepository(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<List<RolesViewModel>> GetAll()
        {
            var roles = await _roleManager.Roles
               .Select(x => new RolesViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description
               }).ToListAsync();

            return roles;
        }
    }
}
