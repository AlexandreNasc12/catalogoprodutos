namespace catalogoprodutos.api.Domain;

public class Produto
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string Foto { get; private set; }
    public decimal Preco { get; private set; }
    public DateTime DataDeCadastro { get; private set; }

    //EF
    private List<Categoria> _Categorias;
    public IReadOnlyCollection<Categoria> Categorias => _Categorias;

    protected Produto(){
        _Categorias = new List<Categoria>();
    }

    public Produto(string nome, string descricao, string foto, decimal preco) : this()
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Foto = foto;
        Preco = preco;
        DataDeCadastro = DateTime.Now;
    }

}