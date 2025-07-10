using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace Infrastructure.Repositories.Service;

public class GenrateToken : IGenerateToken
{
    private readonly IConfiguration _configuration;

    public GenrateToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public Task<string> GetAndCreateToken(AppUser user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),

        };



        var Security = _configuration["Token:Secret"];
        var key = Encoding.ASCII.GetBytes(Security);

        SigningCredentials credentials = new SigningCredentials(
            new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
        );
        SecurityTokenDescriptor token = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            Issuer = _configuration["Token:Issuer"],
            SigningCredentials = credentials,
            NotBefore = DateTime.Now
        };
        ///thabet lehne yothhorly fama mchkla arjaa lil video 119-115
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken = tokenHandler.CreateToken(token);
        string tokenString = tokenHandler.WriteToken(securityToken);
        return Task.FromResult(tokenString);
    }
}
