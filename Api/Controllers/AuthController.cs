using ApiLibrary.Services;
using BaseLibrary.DTO;
using BaseLibrary.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : Controller
    {
        private readonly IAuthService _authService = authService;

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (ModelState.IsValid == false) { return BadRequest(ModelState); }
                
            try
            {
                LoginResponse response = await _authService.Login(login);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenDTO refreshToken)
        {
            if (ModelState.IsValid == false) { return BadRequest(ModelState); }
            try
            {
                LoginResponse response = await _authService.Refresh(refreshToken);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
