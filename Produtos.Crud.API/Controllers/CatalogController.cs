using Microsoft.AspNetCore.Mvc;
using Produtos.Crud.API.Models;

namespace Produtos.Crud.API.Controllers;


[ApiController]
[Route("[controller]")]
public class CatalogController: ControllerBase
{
    private List<ModelCatalogo> produto = new List< ModelCatalogo>{

new ModelCatalogo{Id = 1, Nome = "Caneta azul"},
new ModelCatalogo{Id = 2, Nome = "Caneta vermelha"},
};

[HttpGet ("itens")]
public JsonResult GetItems(){


    return new JsonResult(
           produto
        );

}

[HttpGet ("itens/{id}")]
public JsonResult GetItem(int id){

    var item = produto.SingleOrDefault(x => x.Id == id);
    if(item == null){
        Response.StatusCode = 404;
        return new JsonResult(new {message = "Item não encontrado"});
    }

    return new JsonResult(item);
}

[HttpPost ("itens")]
public JsonResult PostItem([FromBody] ModelCatalogo item){

    produto.Add(item);

    return new JsonResult(item);
}
[HttpPut ("itens/{id}")]
public  JsonResult PutItem(int id, [FromBody] ModelCatalogo item){

    var itemAntigo =  produto.FirstOrDefault(x => x.Id == id);
    if(itemAntigo == null){
        Response.StatusCode = 404;
        return new JsonResult(new {message = "Item não encontrado"});
    }

    itemAntigo.Nome = item.Nome;

    return  new JsonResult(itemAntigo);
}
[HttpDelete ("itens/{id}")]
public JsonResult DeleteItem(int id){

    var itemAntigo = produto.FirstOrDefault(x => x.Id == id);
    if(itemAntigo == null){
        Response.StatusCode = 404;
        return new JsonResult(new {message = "Item não encontrado"});
    }

    produto.Remove(itemAntigo);

    return new JsonResult(itemAntigo);
}
 

   
    
    


}
