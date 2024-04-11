using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string SKey;

        public AuthenticationController(IConfiguration conf)
        {
            SKey = conf.GetSection("Settings").GetSection("key").ToString();
        }

        [HttpPost]
        [Route("Validacion")]

        public IActionResult Validar([FromBody] Usuario request) {
        
            if(request.Email == "prueba@prueba.com" && request.Password == "123")
            {
                var KeyToBytes = Encoding.ASCII.GetBytes(SKey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,request.Email));
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyToBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDesc);
                string tokenFinal = tokenHandler.WriteToken(tokenConfig);
                return StatusCode(StatusCodes.Status200OK, new { token = tokenFinal });
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        
        
        
        }


    }
}
