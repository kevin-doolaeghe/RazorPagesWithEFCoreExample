using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Records {

    public class DetailsModel : PageModel {

        private readonly WebApp.Services.DatabaseContext _context;

        public DetailsModel(WebApp.Services.DatabaseContext context) {
            _context = context;
        }

        public Record Record { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id) {
            if (id == null || _context.Records == null) {
                return NotFound();
            }

            var record = await _context.Records
                .Include(r => r.Account)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.RecordId == id);
            if (record == null) {
                return NotFound();
            } else {
                Record = record;
            }
            return Page();
        }
    }
}
