using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;
        public SellerService(SalesWebMVCContext context) => _context = context;

        public async Task<List<Seller>> FindAllAsync() => await _context.Seller.ToListAsync();

        public async Task InsertAsync(Seller seller)
        {
            await _context.AddAsync(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller?> FindByIdAsync(int id) => await _context.Seller.Include(p => p.Department).FirstOrDefaultAsync(p => p.Id == id);

        public async Task RemoveAsync(int id)
        {
            var getRemoveId = await _context.Seller.FindAsync(id) ?? throw new KeyNotFoundException($"Vendedor ID {id} não encontrado");
            bool hasSales = await _context.SalesRecord.AnyAsync(h => h.Seller!.Id == id);
            if (hasSales) throw new InvalidOperationException("Não é possível excluir um vendedor que possui vendas registradas.");

            _context.Seller.Remove(getRemoveId);
            await _context.SaveChangesAsync();
        }

    }
}
