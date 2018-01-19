using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAuthenticationSample.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthenticationSample.Controllers
{
    //[Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        public IConfiguration ConfigurationBinder { get; }
        public TokenController(IConfiguration config)
        {
            ConfigurationBinder = config;
        }

        [Route("Login")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ShowLogin()
        {
            return View();
        }

        [Route("GoToBooks")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult GoToBooks(JwtTokenModel jwtToken)
        {
            return View("GoToBooks",jwtToken);
        }

        [Route("CreateToken")]
        [AllowAnonymous,HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel loginModel)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(loginModel);
            if (user!=null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string BuildToken(UserModel user)
        {
            var claimsArr = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Name),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(JwtRegisteredClaimNames.Birthdate,user.Birthdate.ToString("yyyy-MM-dd")), 
                new Claim(JwtRegisteredClaimNames.Jti,(new Guid()).ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationBinder["Jwt:Key"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:ConfigurationBinder["Jwt:Issuer"],
                audience: ConfigurationBinder["Jwt:Issuer"],
                claims: claimsArr,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:creds
                );

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            return jwtTokenHandler.WriteToken(token);
        }

        private UserModel AuthenticateUser(LoginModel loginModel)
        {
            UserModel user = null;
            if (loginModel.UserName.Equals("XX") && loginModel.Password.Equals("XXX"))
            {
                user = new UserModel { Name = "Mario Rossi", Email = "mario.rossi@domain.com" ,Birthdate = new DateTime(1985,2,9)};
            }
            return user;
        }
    }
}