using Microsoft.AspNetCore.Mvc;

namespace Produtos.Crud.API.Controllers;


[Route("[controller]")]
public class testeController: ControllerBase

{
    
[HttpGet("ping")]
public string Ping ()=> "pong";

[HttpGet("teste")]
public JsonResult TesteObjeto(){


    return new JsonResult(new {nome = "teste", idade = 20});
}
    
}
