using catalogoprodutos.api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace catalogoprodutos.api.Infra.Mappings;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome).HasMaxLength(200).HasColumnName("Nome").IsRequired();

        builder.Property(c => c.Descricao).HasMaxLength(200).HasColumnName("Descricao").IsRequired();

        builder.Property(c => c.Foto).HasMaxLength(200).HasColumnName("Foto");

        builder.Property(c => c.DataDeCadastro).HasDefaultValueSql("GETDATE()").HasColumnName("DataDeCadastro").IsRequired();

        builder.HasMany(c => c.Categorias).WithMany(c => c.Produtos);
    }
}