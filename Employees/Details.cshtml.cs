﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NaviStar_Tables.Data;

namespace NaviStar_Tables.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly NaviStar_Tables.Data.ApplicationDbContext _context;

        public DetailsModel(NaviStar_Tables.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employee
                .Include(e => e.AudID)
                .Include(e => e.Departments)
                .Include(e => e.UserRoles).FirstOrDefaultAsync(m => m.EID == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
