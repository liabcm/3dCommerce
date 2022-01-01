using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Dtos;

namespace PrintStorev3.Services
{
    public interface IProductService
    {
        Task<List<GetProductDto>> GetProducts(int designerId);
        Task<List<GetProductDto>> AddProduct(AddProductDto addProduct);
    }
}
