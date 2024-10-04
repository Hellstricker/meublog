using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace MeuBlog.Shared.Domain
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        public int? PostId { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        [StringLength(500,MinimumLength = 2,ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        public int? AutorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        [NotMapped]
        [DisplayName("Cadastrado em")]
        public DateTime? DataCriacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        [NotMapped]
        [DisplayName("Atualizado em")]
        public DateTime? DataAtualizacao { get; set; }

        [NotMapped]
        public Post? Post { get; set; }
        [NotMapped]
        public Autor? Autor { get; set; }

        public bool PodeSermodificadoOuExcluidoPor(ClaimsPrincipal User)
        {
            if (User.IsInRole(ERoles.Admin.ToString())) return true;
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claimId == null) return false;
            if (Autor == null) return false;
            return Autor.UsuarioAplicacaoId == claimId.Value;
        }
    }
}
