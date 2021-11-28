
using FoodShopServiceAPI;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodShopAdminApp.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ILanguageAPI _languageAPI;

        public LanguagesController(
            ILanguageAPI languageAPI)
        {
            _languageAPI = languageAPI;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var products = await _languageAPI.GetAll();
            return Ok(products);
        }
    }
}
