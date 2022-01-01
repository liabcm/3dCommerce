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
    [Route("cart")]
    public class CartOrderController:ControllerBase
    {
        private readonly ICartOrderService orderService;

        public CartOrderController(ICartOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpGet]
        public async Task<List<GetOrderCartDto>> Get(int buyerId)
        {
            return await orderService.GetCartItems(buyerId);
        }
        [HttpPost]
        public async Task<List<GetOrderCartDto>> Add(AddOrderCartDto addOrderCart)
        {
            return await orderService.AddCartItem(addOrderCart);
        }
        [HttpPut]
        [Route("delete")]
        public async Task<List<GetOrderCartDto>> Delete(int buyerId,int itemId)
        {
            return await orderService.RemoveCartItem(buyerId, itemId);
        }
        [HttpPut]
        [Route("order")]
        public async Task<List<GetOrderCartDto>> Order(int buyerId)
        {
            return await orderService.OrderCartItems(buyerId);
        }
        [HttpPut]
        [Route("cancel")]
        public async Task<List<GetOrderCartDto>> Cancel(int buyerId, int itemId)
        {
            return await orderService.CancelOrder(buyerId, itemId);
        }
        [HttpGet]
        [Route("getorders")]
        public async Task<List<GetOrderCartDto>> GetOrders(int buyerId)
        {
            return await orderService.GetOrders(buyerId);
        }
    }
}
