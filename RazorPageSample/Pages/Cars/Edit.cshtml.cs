using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPageSample.Data;
using RazorPageSample.Models;

namespace RazorPageSample.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly RazorPageSample.Data.CarContext _context;

        public EditModel(RazorPageSample.Data.CarContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ManufacturerId"] = new SelectList(_context.Manufacturer, "ManufacturerId", "ManufacturerId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }

            return RedirectToPage("./Index");
        }
    }
}
