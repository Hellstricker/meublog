using MeuBlog.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBlog.Shared.Data.Configurations
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentarios");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Descricao).HasColumnType("varchar(500)").IsRequired();
            builder.Property(c => c.DataCriacao).HasColumnType("datetime").HasDefaultValueSql("getdate()").ValueGeneratedOnAdd();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate().IsRequired();
            builder.HasOne(c => c.Post).WithMany().HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Autor).WithMany().HasForeignKey(c => c.AutorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
