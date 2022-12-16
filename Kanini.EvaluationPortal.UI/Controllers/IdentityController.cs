using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Kanini.EvaluationPortalFile.DataAccessLayer.Entity;
using Kanini.EvaluationPortalFile.DataAccessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace Kanini.EvaluationPortal.UI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController : ControllerBase
{
    private readonly IUserRepository userRepository;
    public IConfiguration _configuration;
    public IdentityController(IUserRepository _userRepository, IConfiguration configuration)
    {
        this.userRepository = _userRepository;
        this._configuration = configuration;
    }

    [HttpGet("Login")]
    public IActionResult Login(string email, string password)
    {
        User? res = this.userRepository.Login(email,password);

        if(res != null)
        {
            var claims = new[]{
                new Claim("UserId", res.Email),
                new Claim("UserName", res.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
        else{
            return Ok("Invalid Credentials");
        }
        
    }
}
