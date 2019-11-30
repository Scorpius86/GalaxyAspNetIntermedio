using System.Collections.Generic;
using Galaxy.Taller.Api.Models;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public interface IProductApplicationService
    {
        ProductDto GetProduct(int productId);
        List<ProductDto> GetProducts();
    }
}