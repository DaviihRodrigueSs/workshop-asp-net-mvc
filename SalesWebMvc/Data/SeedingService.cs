using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService 
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //DB HAS BEEN SEEDED
            }
            Department d1 = new Department(1,"Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Bob", "bob@gmail.com",new DateTime(1998,4,21),1000.0,d1);
            Seller s2 = new Seller(2, "Mayra", "mayra@gmail.com", new DateTime(1998,1,1), 2000.0,d2);
            Seller s3 = new Seller(3, "Ailton", "ailton@gmail.com", new DateTime(1968,2,21), 2300.0,d3);
            Seller s4 = new Seller(4, "Davi", "davi@gmail.com", new DateTime(1999,10,27), 5000.0,d4);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018,4,23),11.000,SalesStatus.Billed,s4);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 4, 24), 81.000, SalesStatus.Billed, s1);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 5, 2), 19.000, SalesStatus.Billed, s2);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 8, 1), 17.000, SalesStatus.Billed, s3);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 10, 7), 61.000, SalesStatus.Billed, s3);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 11, 8), 51.000, SalesStatus.Billed, s4);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 12, 9), 21.000, SalesStatus.Billed, s4);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 2, 10), 12.000, SalesStatus.Billed, s2);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 3, 12), 13.000, SalesStatus.Billed, s3);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 7, 11), 1.000, SalesStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1,s2,s3,s4);

            _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            _context.SaveChanges();


        }
    }
}
