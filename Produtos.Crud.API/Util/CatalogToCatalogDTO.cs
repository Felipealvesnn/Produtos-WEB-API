using Produtos.Crud.API.Models;
using Produtos.Crud.API.ViewsModels;

namespace Produtos.Crud.API.Util
{
    public static class CatalogToCatalogDTO
    {
        public static CatalogVM ToCatalogDTO(this ModelCatalogo catalog)
        {
            return new CatalogVM
        {
                Nome = catalog.Nome,
                Descricao = catalog.Descricao,
                Preco = catalog.Preco,
                Imagem = catalog.Imagem
            };
        }
         public static CatalogVMForCreate ToCatalogDTOVMCreate(this ModelCatalogo catalog)
        {
            return new CatalogVMForCreate
            {
             
                Nome = catalog.Nome,
                Descricao = catalog.Descricao,
                Preco = catalog.Preco
               
            };
        }
        public static IEnumerable<CatalogVM> ToCatalogDTO(this IEnumerable<ModelCatalogo> catalog)
        {
            return catalog.Select(item => new CatalogVM(){
               
                Nome = item.Nome,
                Descricao = item.Descricao,
                Preco = item.Preco,
                Imagem = item.Imagem

            });
        }
    }
}