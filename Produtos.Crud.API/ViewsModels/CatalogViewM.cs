namespace Produtos.Crud.API.ViewsModels;


public class CatalogVM{
 
   
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    public decimal Preco {get; set;}
    public string Imagem {get; set;} = string.Empty;
}
