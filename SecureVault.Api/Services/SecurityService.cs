using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace SecureVault.Api.Services
{
    public class SecurityService
    {
        private readonly IConfiguration _config;

        public SecurityService(IConfiguration config)
        {
            _config = config;
        }

        public string HashPassword(string plainTextPassword)
        {
            // Implementação de hashing de senha usando um algoritmo seguro como bcrypt.
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }

        public bool VerifyPassword(string plainTextPassword, string savedHash)
        {
            // Verifica se a senha em texto plano corresponde ao hash armazenado.
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, savedHash);
        }

        public string GenerateJwtToken(string email, string role)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Identificador único do token
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // O token expira em 1 hora
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }   
}
