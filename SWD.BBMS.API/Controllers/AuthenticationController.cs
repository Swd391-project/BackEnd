using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SWD.BBMS.API.ViewModels.ResponseModels;
using SWD.BBMS.API.ViewModels.RequestModels;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    //[EnableCors("")]
    public class AuthenticationController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly IJwtService jwtService;

        private readonly SignInManager<User> signInManager;

        private readonly IUserService userService;

        private List<string> Roles { get; set; } = new List<string> { "admin", "manager", "staff", "customer" };

        public AuthenticationController(UserManager<User> userManager, IJwtService jwtService, SignInManager<User> signInManager, IUserService userService)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
            this.signInManager = signInManager;
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest register)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!Roles.Contains(register.Role.Trim().ToLower()))
                {
                    return BadRequest($"Invalid role: {register.Role}.");
                }
                var createdBy = await jwtService.GetUserId();
                var user = new UserModel
                {
                    FullName = register.FullName,
                    UserName = register.Email.IsNullOrEmpty() ? register.PhoneNumber : register.Email,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                    Role = register.Role,
                    CreatedBy = createdBy,
                    ModifiedBy = createdBy,
                    Image = register.Image
                };

                var result = await userService.CreateUser(user, register.Password);
                if(result != true)
                {
                    return BadRequest(result);
                }
                var newUser = await userService.GetUserByUsername(user.UserName);
                var jwtToken = jwtService.GenerateJwtToken(user);
                var tokenResponse = new TokenResponse
                {
                    Token = jwtToken,
                    Id = newUser.Id,
                    FullName = user.FullName,
                    Role = user.Role,
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber
                };
                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = await userService.GetUserByUsername(loginRequest.Username.Trim());
                if (user == null)
                {
                    return Unauthorized("Invalid username.");
                }
                var result = await userService.LoginUser(user, loginRequest.Password);
                if (!result)
                {
                    return Unauthorized("Wrong password.");
                }
                var jwtToken = jwtService.GenerateJwtToken(user);
                var tokenResponse = new TokenResponse
                {
                    Token = jwtToken,
                    Id = user.Id,
                    FullName = user.FullName,
                    Role = user.Role,
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber
                };
                return Ok(tokenResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
