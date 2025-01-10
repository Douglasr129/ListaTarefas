using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class UserDto
    {
        public class RegisterUserDto
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
            public required string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
            public required string Password { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [Compare("Password", ErrorMessage = "As senhas não conferem.")]
            public required string ConfirmPassword { get; set; }
        }

        public class LoginUserDto
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
            public required string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
            public required string Password { get; set; }
        }
        public class UserTokenDto
        {
            public string? Id { get; set; }
            public string? Email { get; set; }
            public IEnumerable<ClaimDto>? Claims { get; set; }
        }

        public class LoginResponseDto
        {
            public string? AccessToken { get; set; }
            public double? ExpiresIn { get; set; }
            public UserTokenDto? UserToken { get; set; }
        }

        public class ClaimDto
        {
            public string? Value { get; set; }
            public string? Type { get; set; }
        }
    }
}
