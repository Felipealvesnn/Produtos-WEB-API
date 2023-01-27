namespace Produtos.Crud.API.Models;

public class ModelCatalogo{
 
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    public decimal Preco {get; set;}
    public string Imagem {get; set;} = string.Empty;
}