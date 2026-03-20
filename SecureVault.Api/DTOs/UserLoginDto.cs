using System.ComponentModel.DataAnnotations;

namespace SecureVault.Api.DTOs
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        // Não limitamos o tamanho máximo aqui para não dar dicas a um atacante sobre as regras de senha do sistema durante o login.
        public string Password { get; set; }
    }
}
