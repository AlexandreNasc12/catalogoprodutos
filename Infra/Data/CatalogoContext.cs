using catalogoprodutos.api.Domain;
using Microsoft.EntityFrameworkCore;

namespace catalogoprodutos.api.Infra.Data;

public class CatalogoContext : DbContext
{
    public DbSet<Categoria> Categorias{ get; set; }

    public DbSet<Produto> Produtos{ get; set; }

    public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
    }
}
