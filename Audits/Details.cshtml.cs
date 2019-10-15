using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NaviStar_Tables.Data;

namespace NaviStar_Tables.Pages.Audits
{
    public class DetailsModel : PageModel
    {
        private readonly NaviStar_Tables.Data.ApplicationDbContext _context;

        public DetailsModel(NaviStar_Tables.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Audit Audit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Audit = await _context.Audit.FirstOrDefaultAsync(m => m.AID == id);

            if (Audit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
