using System.ComponentModel.DataAnnotations;

namespace MeuBlog.Shared.Domain
{
    public class Autor
    {
        [Required(ErrorMessage = "O campo {0} é necessário")]
        public string? Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é necessário")]
        [StringLength(100,MinimumLength = 3, ErrorMessage ="O campo {0} deve conter entre {2} e {1} caracteres")]
        public string? Nome { get; set; }
    }
}
