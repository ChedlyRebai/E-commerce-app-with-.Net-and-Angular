using Api.Helper;
using AutoMapper;
using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            string result = await _unitOfWork.Auth.RegisterAsync(registerDTO);
            if (result != "done")
            {
                return BadRequest(new ResponseAPI(400, result));
            }
            else
            {
                return Ok(new ResponseAPI(200, "User registered successfully"));
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {

            var result = await _unitOfWork.Auth.LoginAsync(loginDTO);
            if (result.StartsWith("please"))
            {
                return BadRequest(new ResponseAPI(400, result));
            }
            Response.Cookies.Append("token", result, new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                Domain = "localhost",
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                IsEssential = true,
                SameSite = SameSiteMode.Strict,
            });

            return Ok(new ResponseAPI(200, "Login successful"));
        }

        [HttpPost("active-account")]
        public async Task<IActionResult> Active(ActiveAccountDTO accountDTO)
        {
            var result = await _unitOfWork.Auth.ActiveAccount(accountDTO);
            Console.WriteLine("Account activation result: " + result);
            Console.WriteLine(result);
            return result
                ? Ok(new ResponseAPI(200, "Account activated successfully"))
                : BadRequest(new ResponseAPI(400, "Failed to activate account"));
        }

        [HttpGet("send-email-forget-password")]
        public async Task<IActionResult> forget(string email)
        {
            var result = await _unitOfWork.Auth.SendEailForgetPassword(email);
            return result
           ? Ok(new ResponseAPI(200, "Account activated successfully"))
           : BadRequest(new ResponseAPI(400, "Failed to activate account"));

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _unitOfWork.Auth.ResetPassword(resetPasswordDTO);
            if (result.StartsWith("done"))
            {
                return Ok(new ResponseAPI(200, "Password reset successfully"));
            }
            else
            {
                return BadRequest(new ResponseAPI(400, result));
            }
        }

        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgeetPasssword(LoginDTO loginDTO)
        {
            var result = await _unitOfWork.Auth.SendEailForgetPassword(loginDTO.Email);
            if (result)
            {
                return Ok(new ResponseAPI(200, "Email sent successfully"));
            }
            else
            {
                return BadRequest(new ResponseAPI(400, "Failed to send email"));
            }
        }
    }
}
