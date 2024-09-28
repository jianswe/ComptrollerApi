// the database context that will manage your database connection and operations.

using Microsoft.EntityFrameworkCore;
using ComptrollerApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ComptrollerApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TaxReport> TaxReports { get; set; }

        
    }
}
