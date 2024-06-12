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
using SWD.BBMS.API.ViewModels.RequestModels;
using System.Text.Json.Serialization;
using System.Text.Json;
using AutoMapper;
using SWD.BBMS.Services.BusinessModels;
using System.Net.Http.Json;
using Microsoft.OpenApi.Extensions;

namespace BadmintonRentalSWD.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        private readonly IMapper mapper;


        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers([FromQuery] OwnerParameters ownerParameters)
        {
            var users = await userService.GetUsers(ownerParameters.PageNumber, ownerParameters.PageSize);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var metadata = new
            {
                users.TotalCount,
                users.PageSize,
                users.CurrentPage,
                users.TotalPages,
                users.HasNext,
                users.HasPrevious
            };
            var userResponses = users.Select(u => new UserListResponse
            {
                Id = u.Id,
                FullName = u.FullName,
                Username = u.UserName,
                Role = u.Role,
                Status = u.Status.GetDisplayName()
            }).ToList();
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
            return Ok(userResponses);
        }

        /*
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
        */

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
                var userModel = await userService.GetUserById(id);
                var userResponse = new UserDetailResponse
                {
                    Id = userModel.Id,
                    FullName = userModel.FullName,
                    Email = userModel.Email,
                    PhoneNumber = userModel.PhoneNumber,
                    Role = userModel.Role,
                    Image = userModel.Image,
                    Status = userModel.Status.GetDisplayName(),
                    CompanyId = userModel.Company != null ? userModel.Company.Id : null,
                    CompanyName = userModel.Company != null ? userModel.Company.Name : null
                };
                return Ok(userResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userDictModel = new UserUpdateDictionary();
                foreach(var keyValuePair in request)
                {
                    userDictModel.Add(keyValuePair.Key, keyValuePair.Value);
                }
                var success = await userService.UpdateUser(id, userDictModel);
                if (success)
                {
                    return Ok("User is updated.");
                }
                return Ok("User is not updated.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        

        /*
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
        */
    }
}
