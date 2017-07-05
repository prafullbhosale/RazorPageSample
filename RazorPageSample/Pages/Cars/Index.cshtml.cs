using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageSample.Data;
using RazorPageSample.Models;

namespace RazorPageSample.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageSample.Data.CarContext _context;

        public IndexModel(RazorPageSample.Data.CarContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }

        public async Task OnGetAsync()
        {
            Car = await _context.Car
                .Include(c => c.Manufacturer).ToListAsync();
        }
    }
}
