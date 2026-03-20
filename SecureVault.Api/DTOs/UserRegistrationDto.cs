using System.ComponentModel.DataAnnotations;

namespace SecureVault.Api.DTOs
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "O nome é obrigátório.")]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O email deve ser válido.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$", ErrorMessage = "Formato de e-mail inválido e não pode conter espaços.")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string Password { get; set; }
    }
}
