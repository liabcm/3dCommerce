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
    public class PrinterOrderService : IPrinterOrderService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public PrinterOrderService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<GetPersonDto> AssignPrinter(int printerId, int buyerId)
        {
            var orders = context.Order.Where(c => c.BuyerId == buyerId && c.IsDeleted == false && c.Status == 1);
            
            foreach (Order order in orders)
            {
                order.PrinterId = printerId;
                order.Status = 2;
            }
            context.SaveChanges();
            GetPersonDto printer = mapper.Map<GetPersonDto>(context.Person.FirstOrDefault(p => p.Id == printerId));
            return printer;
            //individual order items will need broken out not just foreach loop for all--printer can have single item in larger order   
        }

        public Task<List<GetOrderCartDto>> GetAvailableOrders()
        {
            throw new NotImplementedException();
        }

        public Task<List<GetOrderCartDto>> GetPrinterOrders(int printerId)
        {
            throw new NotImplementedException();
        }
    }
}
