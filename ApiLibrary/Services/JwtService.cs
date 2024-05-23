using ApiLibrary.Helpers;
using BaseLibrary.DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApiLibrary.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSection _jwtSection;

        public JwtService(IOptions<JwtSection> config)
        {
            _jwtSection = config.Value;
        }

        public string GenerateToken(OCompanyDTO user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSection.Key!));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Surname, user.Role),
                new Claim("CreatedAt", user.CreatedAt.ToString("o")),
                new Claim("UpdatedAt", user.UpdatedAt?.ToString("o") ?? ""),
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSection.Issuer,
                audience: _jwtSection.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public OCompanyDTO? GetComapnyFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSection.Issuer,
                ValidAudience = _jwtSection.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSection.Key!))
            };

            try
            {
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                if (principal?.Identity is ClaimsIdentity identity)
                {
                    return new OCompanyDTO
                    {
                        Id = int.Parse(identity.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? ""),
                        Name = identity.FindFirst(ClaimTypes.Name)?.Value!,
                        Email = identity.FindFirst(ClaimTypes.Email)?.Value!,
                        Role = identity.FindFirst(ClaimTypes.Role)?.Value!,
                        CreatedAt = DateTime.Parse(identity.FindFirst("CreatedAt")?.Value ?? ""),
                        UpdatedAt = DateTime.TryParse(identity.FindFirst("UpdatedAt")?.Value, out var updatedAt)
                                    ? updatedAt
                                    : null
                    };
                }
            }
            catch (SecurityTokenException)
            {
                throw new Exception("Invalid token");
            }

            return null;
        }


        public string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    }
}
