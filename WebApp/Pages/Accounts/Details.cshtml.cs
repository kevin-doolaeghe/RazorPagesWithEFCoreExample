using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Accounts {

    public class DetailsModel : PageModel {

        private readonly WebApp.Services.DatabaseContext _context;

        public DetailsModel(WebApp.Services.DatabaseContext context) {
            _context = context;
        }

        public Account Account { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id) {
            if (id == null || _context.Accounts == null) {
                return NotFound();
            }

            var account = await _context.Accounts
                .Include(a => a.Records)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.AccountId == id);
            if (account == null) {
                return NotFound();
            } else {
                Account = account;
            }
            return Page();
        }
    }
}
