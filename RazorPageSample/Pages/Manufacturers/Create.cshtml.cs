using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageSample.Data;
using RazorPageSample.Models;

namespace RazorPageSample.Pages.Manufacturers
{
    public class CreateModel : PageModel
    {
        private readonly RazorPageSample.Data.CarContext _context;

        public CreateModel(RazorPageSample.Data.CarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Manufacturer.Add(Manufacturer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}