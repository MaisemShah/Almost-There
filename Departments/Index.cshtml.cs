using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NaviStar_Tables.Data;

namespace NaviStar_Tables.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly NaviStar_Tables.Data.ApplicationDbContext _context;

        public IndexModel(NaviStar_Tables.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }

        public async Task OnGetAsync()
        {
            Department = await _context.Department.ToListAsync();
        }
    }
}
