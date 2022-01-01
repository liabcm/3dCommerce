using PrintStorev3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrintStorev3.data;
using Microsoft.EntityFrameworkCore;
using PrintStorev3.Models;

namespace PrintStorev3.Services
{
    public class CartOrderService : ICartOrderService
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public CartOrderService(DataContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<GetOrderCartDto>> AddCartItem(AddOrderCartDto addOrderCart)
        {
            addOrderCart.Product = context.Product.FirstOrDefault(p => p.Id == addOrderCart.Product.Id);
            context.Order.Add(mapper.Map<Order>(addOrderCart));
            context.SaveChanges();
            return await context.Order.Where(s => s.BuyerId == addOrderCart.BuyerId && s.IsDeleted == false && s.Status == 0).Include(s => s.Product)
                            .Select(s => mapper.Map<GetOrderCartDto>(s)).ToListAsync();
        }

        public async Task<List<GetOrderCartDto>> GetCartItems(int buyerId)
        {
            return await context.Order.Where(s => s.BuyerId == buyerId && s.IsDeleted == false && s.Status == 0).Include(s=>s.Product)
                .Select(s => mapper.Map<GetOrderCartDto>(s)).ToListAsync();
        }

        public async Task<List<GetOrderCartDto>> OrderCartItems(int buyerId)
        {
            var orders = context.Order.Where(c => c.BuyerId == buyerId && c.IsDeleted == false && c.Status == 0);
            foreach(Order order in orders)
            {
                order.Status = 1;
            }
            context.SaveChanges();
            return await context.Order.Where(s => s.BuyerId == buyerId && s.IsDeleted == false&&s.Status==1).Include(s => s.Product)
                .Select(s => mapper.Map<GetOrderCartDto>(s)).ToListAsync();
        }

        public async Task<List<GetOrderCartDto>> RemoveCartItem(int buyerId, int itemId)
        {
            Order order = context.Order.Where(c => c.BuyerId == buyerId && c.Product.Id == itemId&&c.IsDeleted==false && c.Status == 0).Include(c => c.Product).FirstOrDefault();
            order.IsDeleted = true;
            context.SaveChanges(); 
            return await context.Order.Where(s => s.BuyerId == buyerId && s.IsDeleted == false && s.Status == 0).Include(s => s.Product)
                            .Select(s => mapper.Map<GetOrderCartDto>(s)).ToListAsync();
        }
        public async Task<List<GetOrderCartDto>> CancelOrder(int buyerId, int itemId)
        {
            Order order = context.Order.Where(c => c.BuyerId == buyerId && c.Product.Id == itemId && c.IsDeleted == false && c.Status != 0).Include(c => c.Product).FirstOrDefault();
            order.IsDeleted = true;
            context.SaveChanges();
            return await context.Order.Where(s => s.BuyerId == buyerId && s.IsDeleted == false && s.Status != 0).Include(s => s.Product)
                .Select(s => mapper.Map<GetOrderCartDto>(s)).ToListAsync();
        }
        //c.Status will need changed in Order order = where statement

        public async Task<List<GetOrderCartDto>> GetOrders(int buyerId)
        {
            return await context.Order.Where(s => s.BuyerId == buyerId && s.IsDeleted == false && s.Status != 0).Include(s => s.Product)
                .Select(s => mapper.Map<GetOrderCartDto>(s)).ToListAsync();
        }
        //s.Status will need changed where statement

        
    }
}
