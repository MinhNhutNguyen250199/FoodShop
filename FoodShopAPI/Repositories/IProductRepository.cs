using FoodShopModel.Common;
using FoodShopModel.Images;
using FoodShopModel.Products;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopAPI.Repositories
{
    public interface IProductRepository
    {

        Task<Guid> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(Guid productId);

        Task<ProductViewModel> GetById(Guid productId, string languageId);

        Task<bool> UpdatePrice(Guid productId, decimal newPrice);

        Task<bool> UpdateStock(Guid productId, int addedQuantity);

        Task AddViewcount(Guid productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<Guid> AddImage(Guid productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(Guid imageId);

        Task<int> UpdateImage(Guid imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(Guid imageId);

        Task<List<ProductImageViewModel>> GetListImages(Guid productId);
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

        Task<ApiResult<bool>> CategoryAssign(Guid id, CategoryAssignRequest request);

        Task<List<ProductViewModel>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductViewModel>> GetLatestProducts(string languageId, int take);
    }
}
