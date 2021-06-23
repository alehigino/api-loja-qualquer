using System.ComponentModel.DataAnnotations;

namespace LojaQualquer.WebApi.Domain.Models.Request
{
    public class LoginRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório informar o email.")]
        [MaxLength(128, ErrorMessage = "O email deve conter até 128 caracteres.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "É obrigatório informar a senha.")]
        [MaxLength(30, ErrorMessage = "A senha deve conter até 30 caracteres.")]
        public string Password { get; set; }
    }
}