// the database context that will manage your database connection and operations.

using Microsoft.EntityFrameworkCore;
using ComptrollerApi.Models;

namespace ComptrollerApi.Data
{
    public class TaxReportDbContext : DbContext
    {
        public TaxReportDbContext(DbContextOptions<TaxReportDbContext> options) : base(options)
        {
        }

        public DbSet<TaxReport> TaxReports { get; set; }

        
    }
}
