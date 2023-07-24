using Jwt.Constants;
using Jwt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;   
        }

        [HttpPost]
        public IActionResult Login(LoginUser loginUser)
        {
            var user = Authenticate(loginUser);

            if(user != null)
            {
                // Crear token
                var token = Generate(user);

                return Ok(token);
            }
            return NotFound("Usuario no encontrado");
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hola {currentUser.Firstname}, tu eres un {currentUser.Rol}");
        }

        private UserModel Authenticate(LoginUser loginUser)
        {
            var currentUser = UserConstants.Users.FirstOrDefault(
                        user => user.Username.ToLower() == loginUser.Username.ToLower()
                        && user.Password == loginUser.Password
                        );

            if(currentUser != null)
                {
                return currentUser;
                }

            return null;
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256 );


            // Crear los  claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Firstname),
                new Claim(ClaimTypes.Surname, user.Lastname),
                new Claim(ClaimTypes.Role, user.Rol),

            };

            // Crear los token

            var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(14),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
            }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClains = identity.Claims;

                return new UserModel
                {
                    Username = userClains.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userClains.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Firstname = userClains.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    Lastname = userClains.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    Rol = userClains.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                };
            }

            return null;
        }
    }
}
