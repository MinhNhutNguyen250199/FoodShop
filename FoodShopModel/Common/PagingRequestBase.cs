using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FoodShopModel.Common
{
    public class PagingRequestBase 
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
    }
}
