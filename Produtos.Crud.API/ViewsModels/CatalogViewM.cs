namespace Produtos.Crud.API.ViewsModels;


public class CatalogVM{
 
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    public decimal Preco {get; set;}
}