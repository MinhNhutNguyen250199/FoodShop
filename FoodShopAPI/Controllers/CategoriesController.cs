using FoodShopAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryrepository;

        public CategoriesController(
            ICategoryRepository categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _categoryrepository.GetAll(languageId);
            return Ok(products);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId, Guid id)
        {
            var category = await _categoryrepository.GetById(languageId, id);
            return Ok(category);
        }


    }
}
