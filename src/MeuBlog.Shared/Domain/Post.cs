using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace MeuBlog.Shared.Domain
{
    public class Post
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é necessário")]
        [StringLength(100,MinimumLength = 10, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        [StringLength(1000, MinimumLength = 100, ErrorMessage = "O Campo {0} deve conter entre {2} e {1} caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        [NotMapped]
        [DisplayName("Publicado em")]
        public DateTime? DataPublicacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        [NotMapped]
        [DisplayName("Atualizado em")]
        public DateTime? DataAtualizacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é necessário")]
        public string? AutorId { get; set; }
        
        [NotMapped]
        public Autor? Autor { get; set; }

        public bool PodeSermodificadoOuExcluidoPor(ClaimsPrincipal User)
        {
            if (User.IsInRole(ERoles.Admin.ToString())) return true;
            var claimId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claimId == null) return false;            
            if (Autor == null) return false;            
            return Autor.Id == claimId.Value;
        }
    }
}
