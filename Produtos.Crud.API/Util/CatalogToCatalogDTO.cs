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
                Id = catalog.Id,
                Nome = catalog.Nome,
                Descricao = catalog.Descricao,
                Preco = catalog.Preco
            };
        }
        public static IEnumerable<CatalogVM> ToCatalogDTO(this IEnumerable<ModelCatalogo> catalog)
        {
            return catalog.Select(item => new CatalogVM(){
                Id = item.Id,
                Nome = item.Nome,
                Descricao = item.Descricao,
                Preco = item.Preco

            });
        }
    }
}