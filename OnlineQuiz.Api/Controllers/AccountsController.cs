using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }


            // This provides the UrlHelper instance
            var urlHelper = Url;

            // Pass the urlHelper to the Register method
            var response = await _accountManager.Register(registerDto, urlHelper);

            if (response.successed)
            {

                // return CreatedAtAction(nameof(Register), response);
                return Ok(new { message = "Register successful" });

            }


            return BadRequest(response.Errors);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }

            var response = await _accountManager.Login(loginDto);

            if (response.successed)
            {
             return Ok(new { message = "Login successful" });
            }

            // Return unauthorized if login failed
            return Unauthorized(response.Errors);
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }
            var responce = await _accountManager.ConfirmEmail(userId, token);
            if (responce.successed)
                
            {
                return Ok(new { message = "Email confirmed successfully" });
            }
            return BadRequest(responce.Errors);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }

            var UrlHepler = Url;
            var result = await _accountManager.ForgotPassword(forgotPasswordDto , UrlHepler);
            if(result.successed)
            {
                return Ok(new { message = "Password reset email sent successfully. Please check your inbox." });
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Errors = "Invalid input data" });
            }

            var UrlHepler = Url;
            var result = await _accountManager.ResetPassword(resetPasswordDto);
            if (result.successed)
            {
                return Ok(new { message = "Your password has been reset successfully." });
            }
            return BadRequest(result.Errors);
        }
    }
}
