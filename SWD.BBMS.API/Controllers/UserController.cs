using SWD.BBMS.Services.Interfaces;
using SWD.BBMS.Repositories.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using SWD.BBMS.API.ViewModels.ResponseModels;

namespace BadmintonRentalSWD.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        private readonly UserManager<User> userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userResponses = users.Select(u => new UserListResponse
            {
                Id = u.Id,
                FullName = u.FullName,
                Username = u.UserName,
                Role = u.Role
            }).ToList();
            return Ok(userResponses);
        }

        [HttpGet("role")]
        [Authorize]
        public async Task<IActionResult> GetRoles()
        {

            var user = GetCurrentUser();
            if (user == null)
            {
                return Ok("No identity user.");
            }
            return Ok("Hello " + user.FullName + ", you are a/an " + user.Role);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                userService.CreateUser(user);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok("New user is created.");
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return Ok("There is no user with id " + id + ".");
                }
                var userResponse = new UserDetailResponse
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Role,
                    Image = user.Image,
                    CompanyId = user.Company != null ? user.Company.Id : null,
                    CompanyName = user.Company != null ? user.Company.Name : null
                };
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
            {
                return null;
            }
            var userClaims = identity.Claims;
            var username = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            if (username.IsNullOrEmpty())
            {
                return null;
            }
            var user = userService.GetUserByUsername(username);
            return user;
        }
    }
}
