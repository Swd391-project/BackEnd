using BadmintonRentalSWD.Entities;
using BadmintonRentalSWD.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        [ProducesResponseType(200, Type = typeof(List<User>))]
        public IActionResult GetUsers()
        {
            var users = userService.GetUsers();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
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
        [ProducesResponseType(200, Type = typeof(User))]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = userService.GetUserById(id);
            if (user == null)
            {
                return Ok("There is no user with id " + id +".");
            }
            return Ok(user);
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
