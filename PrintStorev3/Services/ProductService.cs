using PrintStorev3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrintStorev3.data;
using PrintStorev3.Models;
using Microsoft.EntityFrameworkCore;

namespace PrintStorev3.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public ProductService(IMapper mapper,DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<List<GetProductDto>> AddProduct(AddProductDto addProduct)
        {
            context.Product.Add(mapper.Map<Product>(addProduct));
            context.SaveChanges();
            return await context.Product.Where(p => p.DesignerId == addProduct.DesignerId).Select(p=>mapper.Map<GetProductDto>(p)).ToListAsync();
        }

        public async Task<List<GetProductDto>> GetProducts(int designerId)
        {
            return await context.Product.Where(p => p.DesignerId == designerId).Select(p => mapper.Map<GetProductDto>(p)).ToListAsync();
        }
    }
}
