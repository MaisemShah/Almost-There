using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaviStar_Tables.Data;

namespace NaviStar_Tables.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly NaviStar_Tables.Data.ApplicationDbContext _context;

        public EditModel(NaviStar_Tables.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AID"] = new SelectList(_context.Audit, "AID", "AID");
           ViewData["DID"] = new SelectList(_context.Department, "DID", "DID");
           ViewData["USRID"] = new SelectList(_context.Set<UserRole>(), "USRID", "USRID");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.EID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EID == id);
        }
    }
}
