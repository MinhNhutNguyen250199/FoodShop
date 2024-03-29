﻿using FoodShopModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShopModel.Products
{
    public class CategoryAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}
