using EAuction.APIGateway.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EAuction.APIGateway.Services
{
    public class AuctionTokenService
    {
        public AuthToken GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_eauction_app_secret_key"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expirationDate = DateTime.UtcNow.AddMinutes(15);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FirstName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(audience: "auctionAudience",
                                             issuer: "auctionIssuer",
                                             claims: claims,
                                             expires: expirationDate,
                                             signingCredentials: credentials);

            var authToken = new AuthToken();
            authToken.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authToken.ExpirationDate = expirationDate;

            return authToken;
        }
    }
}
