using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopModel.Users
{
    public class FoodShopException : Exception
    {
        public FoodShopException()
        {
        }

        public FoodShopException(string message)
            : base(message)
        {
        }

        public FoodShopException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
