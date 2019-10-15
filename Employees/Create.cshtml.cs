using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NaviStar_Tables.Data;

namespace NaviStar_Tables.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly NaviStar_Tables.Data.ApplicationDbContext _context;

        public CreateModel(NaviStar_Tables.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AID"] = new SelectList(_context.Audit, "AID", "AID");
        ViewData["DID"] = new SelectList(_context.Department, "DID", "DID");
        ViewData["USRID"] = new SelectList(_context.Set<UserRole>(), "USRID", "USRID");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
