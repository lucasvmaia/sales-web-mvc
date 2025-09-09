using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCContext _context;
        public SalesRecordService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = _context.SalesRecord.AsQueryable();
            if (minDate.HasValue)
                result = result.Where(p => p.Date >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(p => p.Date <= maxDate.Value);

            return await result
                .Include(x => x.Seller)
                .ThenInclude(d => d!.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
