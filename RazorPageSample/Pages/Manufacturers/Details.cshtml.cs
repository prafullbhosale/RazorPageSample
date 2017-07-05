using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageSample.Data;
using RazorPageSample.Models;

namespace RazorPageSample.Pages.Manufacturers
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageSample.Data.CarContext _context;

        public DetailsModel(RazorPageSample.Data.CarContext context)
        {
            _context = context;
        }

        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Manufacturer = await _context.Manufacturer.SingleOrDefaultAsync(m => m.ManufacturerId == id);

            if (Manufacturer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
