using ComptrollerApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ComptrollerApi.Data
{
    public class TaxReportRepository
    {
        private readonly ApplicationDbContext _context; // allow the repository to interact with the database instead of using in-memory storage.

        public TaxReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxReport>> GetAllAsync() => await _context.TaxReports.ToListAsync();

        public async Task<TaxReport> GetByIdAsync(int id) => await _context.TaxReports.FindAsync(id);

        public async Task AddAsync(TaxReport report)
        {
            _context.TaxReports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaxReport report)
        {
            _context.Entry(report).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var report = await GetByIdAsync(id);
            if (report != null)
            {
                _context.TaxReports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }
    }
}
