using System;
using catalogoprodutos.api.Domain;

namespace catalogoprodutos.api.ViewModels;

public class CategoriaViewModel
{
    public Guid Id { get; set; }

    public string Descricao { get; set; }

    public static CategoriaViewModel Mapear(Categoria categoria)
    {
        return new CategoriaViewModel()
        {
            Id = categoria.Id,
            Descricao = categoria.Descricao
        };
    }
}
