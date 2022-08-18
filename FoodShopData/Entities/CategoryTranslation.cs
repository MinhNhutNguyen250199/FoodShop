using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace FoodShopData.Entities
{
    public class CategoryTranslation
    {
        public Guid Id { set; get; }
        public Guid CategoryId { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }

        public Category Category { get; set; }

        public Language Language { get; set; }
    }
}
