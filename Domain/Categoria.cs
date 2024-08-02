namespace catalogoprodutos.api.Domain;

public class Categoria
{
    public Guid Id { get; private set; }

    public string Descricao { get; private set; }

    //EF
    private List<Produto> _Produtos;
    public IReadOnlyCollection<Produto> Produtos => _Produtos;

    protected Categoria(){
        _Produtos = new List<Produto>();
    }

    public Categoria(string descricao) : this()
    {
        Id = Guid.NewGuid();
        Descricao = descricao;
    }

    public void AtribuirDescricao(string descricao) => Descricao = descricao;

    public void Adicionar(Produto produto) => _Produtos.Add(produto);
    public void Remover(Produto produto) => _Produtos.Remove(produto);
}