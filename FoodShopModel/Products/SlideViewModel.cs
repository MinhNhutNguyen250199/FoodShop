﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShopModel.Products
{
    public class SlideViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Url { set; get; }

        public string Image { get; set; }
        public int SortOrder { get; set; }
    }
}
