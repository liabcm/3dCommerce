using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStorev3.Dtos
{
    public class AddProductDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rate { get; set; }
        public int DesignerId { get; set; }
    }
}
