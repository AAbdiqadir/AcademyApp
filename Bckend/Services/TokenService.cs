using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bckend.Interface;
using Bckend.entities;
using Microsoft.IdentityModel.Tokens;

namespace Bckend.Services;

public class TokenService(IConfiguration configuration): ITokenService
{
    public string CreateToken(Appuser appuser)
    { 
        var tokenkey = configuration["TokenKey"]?? throw new Exception("cannot access key form appsettinsg");

        if (tokenkey.Length < 69)
        {throw new Exception("Your Toke key should be longer");}
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenkey));

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, appuser.LastName)
        };
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescripter = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };
        var TokenHandler = new JwtSecurityTokenHandler();
        
        var token = TokenHandler.CreateToken(tokenDescripter);
        
        return TokenHandler.WriteToken(token);
        
        
    }
    
}