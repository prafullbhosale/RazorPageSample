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
    public class IndexModel : PageModel
    {
        private readonly RazorPageSample.Data.CarContext _context;

        public IndexModel(RazorPageSample.Data.CarContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; }

        public async Task OnGetAsync()
        {
            Manufacturer = await _context.Manufacturer.ToListAsync();
        }
    }
}
