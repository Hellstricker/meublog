using System.ComponentModel.DataAnnotations;

namespace MeuBlog.Api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo {0} é necessário")]
        [EmailAddress(ErrorMessage = "{0} inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
