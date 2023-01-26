using Microsoft.AspNetCore.Mvc;
using Produtos.Crud.API.Models;
using Produtos.Crud.API.Util;
using Produtos.Crud.API.ViewsModels;

namespace Produtos.Crud.API.Controllers;


[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private List<ModelCatalogo> produto = new List<ModelCatalogo>{

new ModelCatalogo{Id = 1, Nome = "Caneta azul"},
new ModelCatalogo{Id = 2, Nome = "Caneta vermelha"},
};


    [HttpGet("itens")]
    public ActionResult<IEnumerable<ModelCatalogo>> GetItems()
    {
        var produtos = CatalogToCatalogDTO.ToCatalogDTO(produto);

        return Ok(
               produtos
            );

    }

    [HttpGet("itens/{id}")]
    public ActionResult<ModelCatalogo> GetItem(int id)
    {
       

        var item = produto.SingleOrDefault(x => x.Id == id);
        if (item == null)
        {
            Response.StatusCode = 404;
            return NotFound();             //new JsonResult(new {message = "Item não encontrado"});
        }

        return Ok(item.ToCatalogDTO());
    }

    [HttpPost("itens")]
    public ActionResult PostItem([FromBody] ModelCatalogo item)
    {

        produto.Add(item);

        Response.StatusCode = 201;
        return Ok(produto);      //new JsonResult(produto);
    }
    [HttpPut("itens/{id}")]
    public ActionResult PutItem(int id, [FromBody] ModelCatalogo item)
    {

        var itemAntigo = produto.FirstOrDefault(x => x.Id == id);
        if (itemAntigo == null)
        {
            Response.StatusCode = 404;
            return NotFound();                    //new JsonResult(new {message = "Item não encontrado"});
        }

        itemAntigo.Nome = item.Nome;

        return new JsonResult(itemAntigo);
    }
    [HttpDelete("itens/{id}")]
    public ActionResult DeleteItem(int id)
    {

        var itemAntigo = produto.FirstOrDefault(x => x.Id == id);
        if (itemAntigo == null)
        {
            Response.StatusCode = 404;
            return new JsonResult(new { message = "Item não encontrado" });
        }

        produto.Remove(itemAntigo);

        return Ok(itemAntigo);
    }



    bool existeId(int id)
    {
        return produto.Any(x => x.Id == id);
    }



}
