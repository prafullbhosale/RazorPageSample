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
    public class DetailsModel : PageModel
    {
        private readonly RazorPageSample.Data.CarContext _context;

        public DetailsModel(RazorPageSample.Data.CarContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car
                .Include(c => c.Manufacturer).SingleOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
