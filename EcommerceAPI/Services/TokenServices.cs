using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EcommerceAPI.Services
{
    public class TokenServices
    {
        public string GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Minha-Chave-ultra-mega-secreta-Secreta-Senai"));

            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "ecommerce",
                audience: "ecommerce",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds


                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
