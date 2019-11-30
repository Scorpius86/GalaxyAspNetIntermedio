using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galaxy.Taller.Api.ApplicationServices;
using Galaxy.Taller.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galaxy.Taller.Api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductApplicationService _productApplicationService { get; set; }
        public ProductsController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }
        [HttpGet]
        public ActionResult<List<ProductDto>> GetProducts()
        {
            List<ProductDto> products = _productApplicationService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            ProductDto product = _productApplicationService.GetProduct(productId);
            return Ok(product);
        }
    }
}