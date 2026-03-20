using Microsoft.AspNetCore.Mvc;
using SecureVault.Api.Data;
using SecureVault.Api.DTOs;
using SecureVault.Api.Models;
using SecureVault.Api.Services;

namespace SecureVault.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SecurityService _security;
        private readonly AppDbContext _context;

        public AuthController(SecurityService security, AppDbContext context)
        {
            _security = security;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto model)
        {
            // 1. Verificar se o usuário já existe (Segurança: Evitar duplicidade)
            if (_context.Users.Any(u => u.Email == model.Email))
                return BadRequest("Este e-mail já está cadastrado.");

            // 2. Criar o novo usuário com a senha CRIPTOGRAFADA
            var user = new User
            {
                Email = model.Email,
                PasswordHash = _security.HashPassword(model.Password) // Aqui entra o BCrypt!
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Usuário criado com sucesso no banco de dados!" });
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto loginData)
        {
            // 1. Buscar o usuário no banco pelo e-mail
            var user = _context.Users.FirstOrDefault(u => u.Email == loginData.Email);

            if (user == null)
                return Unauthorized(new { message = "Credenciais inválidas." });

            // 2. Verificar se a senha bate com o hash salvo
            if (!_security.VerifyPassword(loginData.Password, user.PasswordHash))
                return Unauthorized(new { message = "Credenciais inválidas." });

            // 3. Gerar o token se tudo estiver certo
            var token = _security.GenerateJwtToken(user.Email, user.Role);
            return Ok(new { token });
        }
    }
}
