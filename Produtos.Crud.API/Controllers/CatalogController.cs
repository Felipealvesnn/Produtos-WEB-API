using Microsoft.AspNetCore.Mvc;
using Produtos.Crud.API.Models;
using Produtos.Crud.API.Util;
using Produtos.Crud.API.ViewsModels;

namespace Produtos.Crud.API.Controllers;


[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private static List<ModelCatalogo> _produto = new List<ModelCatalogo>()
    {
        new ModelCatalogo()
        {
            Id = 1,
            Nome = "Produto 1",
            Descricao = "Descrição do produto 1",
            Preco = 10.00M,
            Imagem = "https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
        },
        new ModelCatalogo()
        {
            Id = 2,
            Nome = "Produto 2",
            Descricao = "Descrição do produto 2",
            Preco = 20.00M,
            Imagem = "https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
        },
        new ModelCatalogo()
        {
            Id = 3,
            Nome = "Produto 3",
            Descricao = "Descrição do produto 3",
            Preco = 30.00M,
            Imagem = "https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
        },
        new ModelCatalogo()
        {
            Id = 4,
            Nome = "Produto 4",
            Descricao = "Descrição do produto 4",
            Preco = 40.00M,
            Imagem = "https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
        },
        new ModelCatalogo()
        {
            Id = 5,
            Nome = "Produto 5",
            Descricao = "Descrição do produto 5",
            Preco = 50.00M,
            Imagem = "https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
        },
        new ModelCatalogo()
        {
            Id = 6,
            Nome = "Produto 6",
            Descricao = "Descrição do produto 6",
            Preco = 60.00M,
            Imagem = "https://www.google.com.br/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png"
        },
        new ModelCatalogo()
        {
            Id = 7,
            Nome = "Produto 7",
            Descricao = "Descrição do produto 7"
            }
            };
            
            


    [HttpGet("itens")]
    public ActionResult<IEnumerable<CatalogVM>> GetItems()
    {
        var produtos = CatalogToCatalogDTO.ToCatalogDTO(_produto);

        return Ok(
               produtos
            );

    }

    [HttpGet("itens/{id}", Name = "GetItens")]
    //[ActionName("GetItens")]
    public ActionResult<CatalogVM> GetItem(int id)
    {
       

        var item = _produto.SingleOrDefault(x => x.Id == id);
        if (item == null)
        {
            Response.StatusCode = 404;
            return NotFound();             //new JsonResult(new {message = "Item não encontrado"});
        }

        return Ok(item.ToCatalogDTO());
    }

    [HttpPost("itens")]
    public ActionResult PostItem([FromBody] CatalogVMForCreate item)
    {
     var id2 = _produto.OrderBy(d=>d.Id).Last().Id + 1;
        var item_produto = new ModelCatalogo()
        {
            Id = id2,
            Nome = item.Nome,
            Descricao = item.Descricao,
            Preco = item.Preco        
        };
        _produto.Add(item_produto);

        Response.StatusCode = 201;
        return CreatedAtRoute("GetItens", new {id=id2}, item_produto);      //new JsonResult(produto);
    }

    [HttpPut("itens/{id}") ]
    public ActionResult PutItem(int id, [FromBody] CatalogVM item)
    {
        //var id2 = _produto.Count + 1;
       
        var itemAntigo = _produto.FirstOrDefault(x => x.Id == id);
        if (itemAntigo == null)
        {
            ModelState.AddModelError("Id", "Id não encontrado");
            Response.StatusCode = 404;
            return ValidationProblem();                    //new JsonResult(new {message = "Item não encontrado"});
        }

        itemAntigo.Nome = item.Nome;
        itemAntigo.Descricao = item.Descricao;
        itemAntigo.Preco = item.Preco;

        return new JsonResult(_produto);
    }
    [HttpDelete("itens/{id}")]
    public ActionResult DeleteItem(int id)
    {

        var itemAntigo = _produto.FirstOrDefault(x => x.Id == id);
        if (itemAntigo == null)
        {
            ModelState.AddModelError("Id", "Id não encontrado");
            Response.StatusCode = 404;
            return ValidationProblem();  
        }

        _produto.Remove(itemAntigo);

        return Ok(itemAntigo);
    }



    bool existeId(int id)
    {
        return _produto.Any(x => x.Id == id);
    }



}
