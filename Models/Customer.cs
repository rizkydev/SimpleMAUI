using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RizkyApps.Models
{
    internal class Customer
    {
        public double Id { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Notes { get; set; }
    }
}
