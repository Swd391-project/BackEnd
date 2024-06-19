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

        public AuthenticationController(UserManager<User> userManager, IJwtService jwtService, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
            this.signInManager = signInManager;
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
                var createdBy = await jwtService.GetUserId();
                var user = new User
                {
                    FullName = register.FullName,
                    UserName = register.Email.IsNullOrEmpty() ? register.PhoneNumber : register.Email,
                    Email = register.Email,
                    PhoneNumber = register.PhoneNumber,
                    Role = register.Role,
                    CreatedBy = createdBy,
                    ModifiedBy = createdBy
                };

                var createdUser = await userManager.CreateAsync(user, register.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(user, register.Role);

                    if (roleResult.Succeeded)
                    {
                        var jwtToken = jwtService.GenerateJwtToken(user);
                        var tokenResponse = new TokenResponse
                        {
                            Token = jwtToken,
                            FullName = user.FullName,
                            Role = user.Role,
                            Image = user.Image,
                        };
                        return Ok(tokenResponse);
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }
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
                var user = await userManager.Users.FirstOrDefaultAsync(u => u.UserName.Equals(loginRequest.Username.Trim()));
                if (user == null)
                {
                    return Unauthorized("Invalid username.");
                }
                var result = await signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
                if (!result.Succeeded)
                {
                    return Unauthorized("Wrong password.");
                }
                var jwtToken = jwtService.GenerateJwtToken(user);
                var tokenResponse = new TokenResponse
                {
                    Token = jwtToken,
                    FullName = user.FullName,
                    Role = user.Role,
                    Image = user.Image
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
