using BadmintonRentalSWD.BusinessObjects;
using BadmintonRentalSWD.Services;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonRentalSWD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
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

        [HttpPost]
        [ProducesResponseType(201)]
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
    }
}
