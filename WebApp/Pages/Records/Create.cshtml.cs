using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Records {

    public class CreateModel : PageModel {

        private readonly WebApp.Services.DatabaseContext _context;

        public CreateModel(WebApp.Services.DatabaseContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId");
            return Page();
        }

        [BindProperty]
        public Record Record { get; set; } = default!;
        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.Records == null || Record == null) {
                return Page();
            }

            _context.Records.Add(Record);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
