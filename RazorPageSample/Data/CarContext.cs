using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageSample.Models;

namespace RazorPageSample.Data
{
    public class CarContext : DbContext
    {
        public CarContext (DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPageSample.Models.Car> Car { get; set; }

        public DbSet<RazorPageSample.Models.Manufacturer> Manufacturer { get; set; }
    }
}
