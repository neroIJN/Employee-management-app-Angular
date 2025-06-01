using Microsoft.AspNetCore.Mvc;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Services;

namespace EmployeeManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly LiteDbService _liteDbService;

        public EmployeeManagementController(LiteDbService liteDbService)
        {
            _liteDbService = liteDbService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Save login attempt
            _liteDbService.SaveLogin(login);

            // Dummy authentication
            if (login.Username == "admin" && login.Password == "1234")
            {
                return Ok(new
                {
                    result = true,
                    data = new { username = login.Username },
                    message = "Login successful"
                });
            }
            return Ok(new
            {
                result = false,
                message = "Invalid username or password"
            });
        }
    }
}