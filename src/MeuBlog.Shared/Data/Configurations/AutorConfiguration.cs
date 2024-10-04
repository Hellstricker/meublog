using MeuBlog.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeuBlog.Shared.Data.Configurations
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
