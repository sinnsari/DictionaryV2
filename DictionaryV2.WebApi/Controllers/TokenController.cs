using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DictionaryV2.Entity.Concreate.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DictionaryV2.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private SignInManager<AppIdentityUser> _signInManager;
        private readonly IConfiguration configuration;

        public TokenController(IConfiguration configuration) {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody]TokenRequest request) {

            if(request.UserName != "sinan") {
                return Unauthorized();
            }

            return Ok(new { newToken = GenerateToken(request.UserName) });
        }

        private string GenerateToken(string userName) {
            var claim = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,userName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                claims:claim,
                expires:DateTime.Now.AddDays(1),
                issuer:this.configuration["Issuer"],
                audience:this.configuration["Audience"],
                signingCredentials:new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["SigningKey"]))
                                            ,SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class TokenRequest {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}