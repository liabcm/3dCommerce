using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrintStorev3.Models;

namespace PrintStorev3.Dtos
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rate { get; set; }
        public int DesignerId { get; set; }
    }
}
