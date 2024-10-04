using Microsoft.AspNetCore.Identity;

namespace MeuBlog.Shared.Domain
{
    public class UsuarioAplicacao : IdentityUser
    {        
        public Autor? Autor { get; set; }
    }
}
