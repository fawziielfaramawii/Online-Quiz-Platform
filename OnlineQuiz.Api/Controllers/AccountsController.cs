using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineQuiz.BLL.Dtos.Accounts;
using OnlineQuiz.BLL.Managers.Accounts;

namespace OnlineQuiz.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = Roles.Student)]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public AccountsController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register (RegisterDto registerDto)
        {
            var response = await _accountManager.Register(registerDto);

            if (response.successed)
            {
                return CreatedAtAction(nameof(Register), response);
            }

         
            return BadRequest(response.Errors);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var response = await _accountManager.Login(loginDto);

            if (response.successed)
            {
                return Ok(response); 
            }

            // Return unauthorized if login failed
            return Unauthorized(response.Errors);
        }
    }
}
