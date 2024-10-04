using System.ComponentModel.DataAnnotations;

namespace MeuBlog.Shared.Domain
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é necessário")]
        [StringLength(100,MinimumLength = 3, ErrorMessage ="O campo {0} deve conter entre {2} e {1} caracteres")]
        public string? Nome { get; set; }
        public string? UsuarioAplicacaoId { get; set; }

        
        public UsuarioAplicacao? UsuarioAplicacao { get; set; }
    }
}
