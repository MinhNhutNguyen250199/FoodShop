﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodShopData.Enums;

namespace FoodShopData.Entities
{
    public class Promotion
    {
        public Guid Id { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public decimal? DiscountAmount { set; get; }
        public string ProductIds { set; get; }
        public string ProductCategoryIds { set; get; }
        public Status Status { set; get; }
        public string Name { set; get; }
    }
}
