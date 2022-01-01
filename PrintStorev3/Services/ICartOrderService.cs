using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Dtos;

namespace PrintStorev3.Services
{
    public interface ICartOrderService
    {
        Task<List<GetOrderCartDto>> GetCartItems(int buyerId);
        Task<List<GetOrderCartDto>> RemoveCartItem(int buyerId,int itemId);
        Task<List<GetOrderCartDto>> AddCartItem(AddOrderCartDto addShoppingCart);
        Task<List<GetOrderCartDto>> OrderCartItems(int buyerId);
        Task<List<GetOrderCartDto>> CancelOrder(int buyerId, int itemId);
        Task<List<GetOrderCartDto>> GetOrders(int buyerId);
    }
}
