using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace TimeSheets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILoginManager _loginManager;
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager, ILoginManager loginManager)
        {
            _userManager = userManager;
            _loginManager = loginManager;
        }

        [AllowAnonymous]        
        [HttpPost("authenticate")]    
        public async Task<IActionResult> Authenticate([FromQuery] User user)
        {
            var token = await _loginManager.Authenticate(user);
            if (string.IsNullOrWhiteSpace(token.AccessToken))
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(token.AccessToken);
        }

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] Guid id)
        {
            var result = _userManager.GetUser(id);

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _userManager.GetUsers();

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var id = await _userManager.CreateUser(request);

            return Ok(id);
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateUserRequest request)
        {
            await _userManager.UpdateUser(id, request);

            return Ok();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _userManager.DeleteUser(id);

            return Ok();
        }
    }
}