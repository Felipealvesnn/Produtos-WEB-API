using System.ComponentModel.DataAnnotations;

namespace Produtos.Crud.API.ViewsModels;

public class CatalogVMForCreate{
 
   [Required]
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    [Required,MaxLength(200)]
    public decimal Preco {get; set;}
  
}