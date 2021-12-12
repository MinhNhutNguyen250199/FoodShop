using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopModel.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "FoodShopDB";

        public const string CartSession = "CartSession";
        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Jwt";
            public const string BaseAddress = "BaseAddress" ;
        }

        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 10;
        }
        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}
