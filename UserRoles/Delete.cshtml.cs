﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NaviStar_Tables.Data;

namespace NaviStar_Tables.Pages.UserRoles
{
    public class DeleteModel : PageModel
    {
        private readonly NaviStar_Tables.Data.ApplicationDbContext _context;

        public DeleteModel(NaviStar_Tables.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserRole UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRole = await _context.UserRole.FirstOrDefaultAsync(m => m.USRID == id);

            if (UserRole == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserRole = await _context.UserRole.FindAsync(id);

            if (UserRole != null)
            {
                _context.UserRole.Remove(UserRole);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
