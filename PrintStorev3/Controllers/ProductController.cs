using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Dtos;
using PrintStorev3.Services;

namespace PrintStorev3.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController:ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<List<GetProductDto>> Get(int designerId)
        {
            return await productService.GetProducts(designerId);
        }
        [HttpPost]
        public async Task<List<GetProductDto>> Add(AddProductDto addProduct)
        {
            return await productService.AddProduct(addProduct);
        }
    }
}
