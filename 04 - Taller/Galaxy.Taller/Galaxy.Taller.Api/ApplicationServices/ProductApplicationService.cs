using Galaxy.Taller.Api.Data.Repository;
using Galaxy.Taller.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.Taller.Api.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {
        public IProductRepository _productRepository { get; set; }
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<ProductDto> GetProducts()
        {
            return _productRepository.GetProducts();
        }
        public ProductDto GetProduct(int productId)
        {
            return _productRepository.GetProduct(productId);
        }
    }
}
