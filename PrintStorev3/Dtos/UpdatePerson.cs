using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStorev3.Dtos
{
    public class UpdatePerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Int16 IsBuyer { get; set; }
        public Int16 IsPrinter { get; set; }
        public Int16 IsDesigner { get; set; }
    }
}
