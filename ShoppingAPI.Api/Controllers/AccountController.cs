using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShoppingAPI.Business.Abstract;
using ShoppingAPI.Entity.DTO.Login;
using ShoppingAPI.Entity.Result;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingAPI.Api.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var user = await _userService.GetAsync(q => q.UserName == loginRequestDTO.UserName && q.Password == loginRequestDTO.Password);

            if (user!=null)
            {
                return NotFound(Sonuc<LoginResponseDTO>.SuccessNoDataFound());
            }
            else
            {
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings : JWTKey"));

                var claims = new List<Claim>();
                claims.Add(new Claim("kullaniciAdi", user.UserName));
                claims.Add(new Claim("kullaniciID", user.id.ToString()));
                claims.Add(new Claim("AdSoyad", user.FirstName + " " + user.LastName));

                var jwt = new JwtSecurityToken(
                    expires:DateTime.Now.AddDays(30),
                    notBefore:DateTime.Now,
                    claims:claims,
                    issuer:"http://asdasd.com",
                    signingCredentials:new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                LoginResponseDTO loginResponseDTO = new()
                {
                    Token = token
                };
                return Ok(Sonuc<LoginResponseDTO>.SuccessWithData(loginResponseDTO));

            }
        }
    }
}
