﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Pages.Records {

    public class IndexModel : PageModel {

        private readonly WebApp.Services.DatabaseContext _context;

        public IndexModel(WebApp.Services.DatabaseContext context) {
            _context = context;
        }

        public IList<Record> Record { get;set; } = default!;

        public async Task OnGetAsync() {
            if (_context.Records != null) {
                Record = await _context.Records
                    .Include(r => r.Account).ToListAsync();
            }
        }
    }
}
