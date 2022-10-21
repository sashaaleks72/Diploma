using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Diploma.Interfaces;
using Diploma.ResponseModels;
using Diploma.ViewModels;
using System;
using System.Threading.Tasks;

namespace Diploma.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPut("users/{id}")]
        public async Task<IActionResult> ChangeProfile([FromRoute] Guid id, [FromBody] ProfileViewModel changedUser)
        {

            try
            {
                await _userService.EditUserProfile(id, changedUser);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }

            return Ok(new { SuccessMessage = "The user data has been changed!" });
        }
         
        [Authorize]
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetProfile([FromRoute] Guid id)
        {
            UserResponse recievedUser = null;

            try
            {
                recievedUser = await _userService.GetUserProfile(id);
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }

            return Ok(recievedUser);
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel newUser)
        {
            AuthResponse authResponse = null;

            try
            {
                authResponse = await _userService.Register(newUser);
            }
            catch (Exception ex)
            {
                return Conflict(new { Error = ex.Message });
            }

            return Ok(authResponse);
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel userToLogin)
        {
            AuthResponse authResponse = null;

            try
            {
                authResponse = await _userService.Login(userToLogin);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }

            return Ok(authResponse);
        }
    }
}
