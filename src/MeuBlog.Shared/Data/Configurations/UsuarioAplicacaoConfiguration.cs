using MeuBlog.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBlog.Shared.Data.Configurations
{
    public class UsuarioAplicacaoConfiguration : IEntityTypeConfiguration<UsuarioAplicacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioAplicacao> builder)
        {
            builder.HasOne(u => u.Autor).WithOne(a => a.UsuarioAplicacao).HasForeignKey<Autor>(a => a.UsuarioAplicacaoId);
        }
    }
}
