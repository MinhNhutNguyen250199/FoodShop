
using FoodShopModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopModel.Products
{
    public class GetPublicProductPagingRequest: PagingRequestBase
    {
        public Guid? CategoryId { get; set; }
    }
}
