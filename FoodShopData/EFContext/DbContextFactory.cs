using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopData.EFContext
{
    public class DbContextFactory : IDesignTimeDbContextFactory<FoodShopDbContext>
    {
        public FoodShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            //add MS.Extension.File.Ex + MS.Ex.Json

            var connectionString = configuration.GetConnectionString("FoodShopDB");

            var optionsBuilder = new DbContextOptionsBuilder<FoodShopDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FoodShopDbContext(optionsBuilder.Options);
        }
    }
}
