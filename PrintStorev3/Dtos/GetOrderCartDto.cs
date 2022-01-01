using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Models;

namespace PrintStorev3.Dtos
{
    public class GetOrderCartDto
    {
        public int Id { get; set; }
        public Int16 Status { get; set; }
        public int BuyerId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
