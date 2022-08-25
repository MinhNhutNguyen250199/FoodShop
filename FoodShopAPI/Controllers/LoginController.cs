using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using FoodShopAPI.Repositories;
using FoodShopAPI.Repository;
using FoodShopData.EFContext;
using FoodShopData.Entities;
using FoodShopModel.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace FoodShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
     
        private readonly IUserRepository _userrepository;
        private readonly FoodShopDbContext _context;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        public LoginController(FoodShopDbContext context, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, UserManager<User> userManager)                     
        {
            _context = context;
            _refreshTokenRepository = refreshTokenRepository;
            _userrepository = userRepository;
            _userManager = userManager;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userrepository.Authencate(request);          
            var refreshtoken = _refreshTokenRepository.GenerateRefreshToken();
            var user = await _userManager.FindByNameAsync(request.UserName);
            user.RefreshToekn = refreshtoken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
             var createRefreshToken = await _userManager.UpdateAsync(user);
            if (!createRefreshToken.Succeeded)
            {
                return BadRequest("Create Refresh Token fail");
            }
            if (string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);           
            //var refreshtoken = _refreshTokenRepository.GenerateRefreshToken();
            var claimAccessToken = _refreshTokenRepository.GetPrincipalFromExpiredToken(request.AccessToken);
            var username = claimAccessToken.Identity.Name;
            var user = _userManager.FindByNameAsync(username).Result;
            //var user = _userManager.GetUserAsync(claimAccessToken).Result;
            if (user is null /*|| user.RefreshToekn != refreshToken*/ || user.RefreshTokenExpiryTime <= DateTime.Now  )
            {
                return BadRequest("Invalid client request");
            }
            var newAccessToken =  _refreshTokenRepository.GenerateAccessToken(claimAccessToken);
            var newRefreshToken = _refreshTokenRepository.GenerateRefreshToken();
            user.RefreshToekn = newRefreshToken;
            var createRefreshToken = await _userManager.UpdateAsync(user);
            if (!createRefreshToken.Succeeded)
            {
                return BadRequest("Create Refresh Token fail");
            }
            return Ok(new AuthenticateRespone() { 
            AccesToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken           
            });
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var user = _userManager.FindByNameAsync(username).Result;
            if (user == null) return BadRequest();
            user.RefreshToekn = null;
            _userManager.UpdateAsync(user);
            return NoContent();
        }

        [HttpPost ("RegisterAdmin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userrepository.Register(request,"admin");
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("RegisterCustomer")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userrepository.Register(request, "Customer");
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userrepository.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userrepository.GetById(id.ToString());
            return Ok(user);
        }

        [HttpGet("paging")]
      
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _userrepository.GetUsersPaging(request);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userrepository.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}/roles")]
        public async Task<IActionResult> RoleAssign(Guid id, [FromBody] RoleAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userrepository.RoleAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }




    }
}
