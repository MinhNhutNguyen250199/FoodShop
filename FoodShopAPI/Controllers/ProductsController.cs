using FoodShopAPI.Repositories;
using FoodShopAPI.Repository;
using FoodShopModel.Images;
using FoodShopModel.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodShopData.Entities;

namespace FoodShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {


        private readonly IProductRepository _productRepository;
        public ProductsController(
            IProductRepository productRepository)
        {

            _productRepository = productRepository;
        }
        [HttpGet("paging")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await _productRepository.GetAllPaging(request);
            return Ok(products);
        }

        //http://localhost:port/Product/id
        [HttpGet("{productId}/{languageId}")]
        public async Task<IActionResult> GetById(Guid productId, string languageId)
        {
            var product = await _productRepository.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productRepository.Create(request);
            if (productId == default(Guid))
            {

                return BadRequest();
            }
            var productVN = await _productRepository.GetById(productId, "vi-VN");
            var productEN = await _productRepository.GetById(productId, "en-US");
            //return Ok("Them moi thanh cong");
            return Ok(new List<ProductViewModel>() { productVN,productEN});
        }
        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] Guid productId, [FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = productId.ToString();
            var affectedResult = await _productRepository.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var affectedResult = await _productRepository.Delete(productId);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        [Authorize]
        public async Task<IActionResult> UpdatePrice(Guid productId, decimal newPrice)
        {
            var isSuccessful = await _productRepository.UpdatePrice(productId, newPrice);
            if (isSuccessful)
                return Ok();

            return BadRequest();
        }

        //Images
        [HttpPost("{productId}/images")]
        [Authorize]
        public async Task<IActionResult> CreateImage(Guid productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productRepository.AddImage(productId, request);
            if (imageId == default(Guid))
                return BadRequest();

            var image = await _productRepository.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
        }

        [HttpPut("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> UpdateImage(Guid imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productRepository.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> RemoveImage(Guid imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productRepository.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }


        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int productId, Guid imageId)
        {
            var image = await _productRepository.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }

        [HttpPut("{id}/Categories")]
        [Authorize]
        public async Task<IActionResult> CategoryAssign(Guid id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productRepository.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("Featured/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts(int take, string languageId)
        {
            var products = await _productRepository.GetFeaturedProducts(languageId, take);
            return Ok(products);
        }

        [HttpGet("latest/{languageId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestProducts(int take, string languageId)
        {
            var products = await _productRepository.GetLatestProducts(languageId, take);
            return Ok(products);
        }

    }
}