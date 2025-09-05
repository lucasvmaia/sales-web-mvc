using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private readonly SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context) => _context = context;

        public async Task SeedAsync()
        {
            if (await _context.Department.AnyAsync() ||
                await _context.Seller.AnyAsync() ||
                await _context.SalesRecord.AnyAsync())
            {
                return;
            }

            Department department01 = new Department("Eletronics");
            Department department02 = new Department("Phone");
            Department department03 = new Department("Fashion");
            Department department04 = new Department("Books");

            Seller seller01 = new("Lucas", "lucas@gmail.com", new DateTime(1998, 4, 20), 1000.0, department01);
            Seller seller02 = new("Mikael", "mikael@gmail.com", new DateTime(1991, 2, 10), 1200.0, department02);
            Seller seller03 = new("Angela", "angela@gmail.com", new DateTime(1995, 10, 03), 900.5, department01);
            Seller seller04 = new("Sabrina", "sabrina@gmail.com", new DateTime(1989, 9, 13), 890.2, department04);
            Seller seller05 = new("Joel", "joel@gmail.com", new DateTime(1990, 3, 02), 2000.0, department03);
            Seller seller06 = new("Samira", "samira@gmail.com", new DateTime(1999, 12, 28), 2630.9, department02);

            SalesRecord r1 = new SalesRecord(new DateTime(2018, 09, 25), 11000.0, SalesStatus.Billed, seller01);
            SalesRecord r2 = new SalesRecord(new DateTime(2018, 09, 4), 7000.0, SalesStatus.Billed, seller05);
            SalesRecord r3 = new SalesRecord(new DateTime(2018, 09, 13), 4000.0, SalesStatus.Canceled, seller04);
            SalesRecord r4 = new SalesRecord(new DateTime(2018, 09, 1), 8000.0, SalesStatus.Billed, seller01);
            SalesRecord r5 = new SalesRecord(new DateTime(2018, 09, 21), 3000.0, SalesStatus.Billed, seller03);
            SalesRecord r6 = new SalesRecord(new DateTime(2018, 09, 15), 2000.0, SalesStatus.Billed, seller01);
            SalesRecord r7 = new SalesRecord(new DateTime(2018, 09, 28), 13000.0, SalesStatus.Billed, seller02);
            SalesRecord r8 = new SalesRecord(new DateTime(2018, 09, 11), 4000.0, SalesStatus.Billed, seller04);
            SalesRecord r9 = new SalesRecord(new DateTime(2018, 09, 14), 11000.0, SalesStatus.Pending, seller06);
            SalesRecord r10 = new SalesRecord(new DateTime(2018, 09, 7), 9000.0, SalesStatus.Billed, seller06);
            SalesRecord r11 = new SalesRecord(new DateTime(2018, 09, 13), 6000.0, SalesStatus.Billed, seller02);
            SalesRecord r12 = new SalesRecord(new DateTime(2018, 09, 25), 7000.0, SalesStatus.Pending, seller03);
            SalesRecord r13 = new SalesRecord(new DateTime(2018, 09, 29), 10000.0, SalesStatus.Billed, seller04);
            SalesRecord r14 = new SalesRecord(new DateTime(2018, 09, 4), 3000.0, SalesStatus.Billed, seller05);
            SalesRecord r15 = new SalesRecord(new DateTime(2018, 09, 12), 4000.0, SalesStatus.Billed, seller01);
            SalesRecord r16 = new SalesRecord(new DateTime(2018, 10, 5), 2000.0, SalesStatus.Billed, seller04);
            SalesRecord r17 = new SalesRecord(new DateTime(2018, 10, 1), 12000.0, SalesStatus.Billed, seller01);
            SalesRecord r18 = new SalesRecord(new DateTime(2018, 10, 24), 6000.0, SalesStatus.Billed, seller03);
            SalesRecord r19 = new SalesRecord(new DateTime(2018, 10, 22), 8000.0, SalesStatus.Billed, seller05);
            SalesRecord r20 = new SalesRecord(new DateTime(2018, 10, 15), 8000.0, SalesStatus.Billed, seller06);
            SalesRecord r21 = new SalesRecord(new DateTime(2018, 10, 17), 9000.0, SalesStatus.Billed, seller02);
            SalesRecord r22 = new SalesRecord(new DateTime(2018, 10, 24), 4000.0, SalesStatus.Billed, seller04);
            SalesRecord r23 = new SalesRecord(new DateTime(2018, 10, 19), 11000.0, SalesStatus.Canceled, seller02);
            SalesRecord r24 = new SalesRecord(new DateTime(2018, 10, 12), 8000.0, SalesStatus.Billed, seller05);
            SalesRecord r25 = new SalesRecord(new DateTime(2018, 10, 31), 7000.0, SalesStatus.Billed, seller03);
            SalesRecord r26 = new SalesRecord(new DateTime(2018, 10, 6), 5000.0, SalesStatus.Billed, seller04);
            SalesRecord r27 = new SalesRecord(new DateTime(2018, 10, 13), 9000.0, SalesStatus.Pending, seller01);
            SalesRecord r28 = new SalesRecord(new DateTime(2018, 10, 7), 4000.0, SalesStatus.Billed, seller03);
            SalesRecord r29 = new SalesRecord(new DateTime(2018, 10, 23), 12000.0, SalesStatus.Billed, seller05);
            SalesRecord r30 = new SalesRecord(new DateTime(2018, 10, 12), 5000.0, SalesStatus.Billed, seller02);

            await _context.Department.AddRangeAsync(department01, department02, department03, department04);
            await _context.Seller.AddRangeAsync(seller01, seller02, seller03, seller04, seller05, seller06);
            await _context.SalesRecord.AddRangeAsync(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12,
                r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            await _context.SaveChangesAsync();
        }

    }
}
