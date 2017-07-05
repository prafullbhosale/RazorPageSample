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

namespace RazorPageSample.Pages.Manufacturers
{
    public class EditModel : PageModel
    {
        private readonly RazorPageSample.Data.CarContext _context;

        public EditModel(RazorPageSample.Data.CarContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Manufacturer).State = EntityState.Modified;

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
