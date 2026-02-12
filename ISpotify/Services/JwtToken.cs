using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ISpotify.Services;

public class JwtToken
{
    private readonly string _issuer ="ISpotify";
    private readonly string _audience = "ISpotifyClient";
    private readonly string _secretKey = "qG71w8+OWFOTbt2y6DRklfgBt5qCgtuapHsTLhplGjY=";

    public string GenerateToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
}