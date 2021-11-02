using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        public  SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if( _context.Department.Any() ||
                _context.SalesRecords.Any() ||
                _context.Seller.Any() )
            {
                return; //DB has been populated
            }
            Department d1 = new Department(1,"All");
            Seller seller1 = new Seller(1, "All","sellers@sellers.com", new DateTime(2000,1,1),1000.0,d1);
            SalesRecord r1 = new SalesRecord(1,new DateTime(2000,1,2),1000.00,SaleStatus.Billed,seller1);

            _context.Department.AddRange(d1);
            _context.Seller.AddRange(seller1);
            _context.SalesRecords.AddRange(r1);

            _context.SaveChanges();
        }
    }

}
