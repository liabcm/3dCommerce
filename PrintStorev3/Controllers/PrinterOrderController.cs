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
    [Route("printorders")]
    public class PrinterOrderController
    {
        private readonly IPrinterOrderService orderService;

        public PrinterOrderController(IPrinterOrderService orderService)
        {
            this.orderService = orderService;
        }
        [HttpPut]
        [Route("assignprinter")]
        public async Task<GetPersonDto> AssignPrinter(int printerId, int buyerId)
        {
            return await orderService.AssignPrinter(printerId, buyerId);
        }
    }
}
