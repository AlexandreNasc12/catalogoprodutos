using catalogoprodutos.api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace catalogoprodutos.api.Infra.Mappings;

public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Descricao)
        .HasMaxLength(200)
        .HasColumnName("Descricao").IsRequired();

        builder.HasMany(c => c.Produtos).WithMany(c => c.Categorias);
    }
}
