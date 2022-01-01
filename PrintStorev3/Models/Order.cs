using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStorev3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Int16 Status { get; set; }
        public int BuyerId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
        public int? PrinterId { get; set; }

    }
} 
