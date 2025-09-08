using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Data;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;

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
            try
            {
                var seller = await _context.Seller.FindAsync(id) ?? throw new NotFoundException($"Vendedor ID {id} não encontrado.");
                var hasSales = await _context.SalesRecord.AnyAsync(h => h.Seller!.Id == id);
                if (hasSales) throw new IntegrityException("Não é possível excluir um vendedor que possui vendas registradas.");

                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) when (ex is not NotFoundException && ex is not IntegrityException)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            var exists = await _context.Seller.AnyAsync(s => s.Id == seller.Id);
            if (!exists) throw new NotFoundException("Id not found");

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }

    }
}
