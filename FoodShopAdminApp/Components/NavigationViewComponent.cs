using FoodShopAdminApp.Models;
using FoodShopModel.Constants;
using FoodShopServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAdminApp.Components
{
    public class NavigationViewComponent: ViewComponent
    {
        private readonly ILanguageAPI _languageAPI;

        public NavigationViewComponent(ILanguageAPI languageAPI)
        {
            _languageAPI  = languageAPI;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageAPI.GetAll();
            
            var currentLanguageId = HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var items = languages.ResultObj.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = currentLanguageId == null ? x.IsDefault : currentLanguageId == x.Id.ToString()
            });
            var navigationVm = new NavigationViewModel()
            {
                CurrentLanguageId = currentLanguageId,
                Languages = items.ToList()
            };

            return View("Default", navigationVm);
        }
    }
}
