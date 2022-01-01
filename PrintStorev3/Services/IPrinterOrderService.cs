using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Dtos;

namespace PrintStorev3.Services
{
    public interface IPrinterOrderService
    {
        Task<GetPersonDto> AssignPrinter(int printerId, int buyerId);
        Task<List<GetOrderCartDto>> GetPrinterOrders(int printerId);
        Task<List<GetOrderCartDto>> GetAvailableOrders();
    }
}
