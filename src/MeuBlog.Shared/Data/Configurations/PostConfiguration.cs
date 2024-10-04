using MeuBlog.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBlog.Shared.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Titulo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("varchar(1000)").IsRequired();
            builder.Property(p => p.DataPublicacao).HasColumnType("datetime").HasDefaultValueSql("getdate()").ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.DataAtualizacao).HasColumnType("datetime").HasDefaultValueSql("getdate()").ValueGeneratedOnAddOrUpdate().IsRequired();
            builder.HasOne(p => p.Autor).WithMany().HasForeignKey(p => p.AutorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
