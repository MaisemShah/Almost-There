using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NaviStar_Tables.Data;

namespace NaviStar_Tables.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NaviStar_Tables.Data.Audit> Audit { get; set; }
        public DbSet<NaviStar_Tables.Data.Department> Department { get; set; }
        public DbSet<NaviStar_Tables.Data.Employee> Employee { get; set; }
        public DbSet<NaviStar_Tables.Data.UserRole> UserRole { get; set; }
    }
}
