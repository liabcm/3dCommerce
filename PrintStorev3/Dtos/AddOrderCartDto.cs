using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Models;
using PrintStorev3.data;

namespace PrintStorev3.Dtos
{
    public class AddOrderCartDto
    {
        public int BuyerId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
