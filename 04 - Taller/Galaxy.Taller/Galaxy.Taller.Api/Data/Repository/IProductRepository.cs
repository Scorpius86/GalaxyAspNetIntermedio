using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.Data.Repository
{
    public interface IProductRepository
    {
        List<ProductDto> GetProducts();
        ProductDto GetProduct(int productId);
    }
}