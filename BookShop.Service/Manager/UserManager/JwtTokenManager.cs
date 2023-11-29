using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BookShop.Domain.Entities;
using BookShop.Web.Option;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookShop.Service.Manager.UserManager;

public class JwtTokenManager
{
    private readonly JwtOption _jwtOption;

    public JwtTokenManager(IOptions<JwtOption> jwtOption)
    {
        _jwtOption = jwtOption.Value;
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
        };
        var signingKey = System.Text.Encoding.UTF32.GetBytes(_jwtOption.SigningKey);
        var security = new JwtSecurityToken(
            issuer: _jwtOption.ValidIssuer,
            audience: _jwtOption.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOption.ExpiresInMinutes),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey),
                algorithm: SecurityAlgorithms.HmacSha256)
        );
        var token = new JwtSecurityTokenHandler().WriteToken(security);
        return token;
    }
    
}