using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageSample.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsNew { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }

    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string Name { get; set; }
    }
}
