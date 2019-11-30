using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        public GalaxyTallerContext _galaxyTallerContext { get; set; }
        public ProductRepository(GalaxyTallerContext galaxyTallerContext)
        {
            _galaxyTallerContext = galaxyTallerContext;
        }

        private IQueryable<ProductDto> QueryGetProducto(int productId=0)
        {
            var query = from p in _galaxyTallerContext.Producto
                        select new ProductDto
                        {
                            ProductId = p.ProductoId,
                            Description = p.Descripcion,
                            BrandDescription = p.Marca.Descripcion,
                            Price = p.Precio,
                            Unit = p.UnidadMedidad
                        };

            if (productId != 0)
            {
                query= query.Where(w => w.ProductId == productId);
            }

            return query;
        }
        public List<ProductDto> GetProducts()
        {
            List<ProductDto> result = QueryGetProducto().ToList();
            return result;
        }
        public ProductDto GetProduct(int productId)
        {
            ProductDto result = QueryGetProducto(productId).FirstOrDefault();
            return result;
        }
    }
}
