﻿using Microsoft.AspNetCore.Mvc;

namespace BadmintonRentalSWD.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DemoController : Controller
    {
        public DemoController() { }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetIntroduction()
        {
            return Ok("Hello, this is Badminton Booking Management System API.");
        }
    }
}
