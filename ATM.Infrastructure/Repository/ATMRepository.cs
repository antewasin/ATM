using ATM.Core.Domain;
using ATM.Core.IRepository;
using ATM.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Infrastructure.Repository
{
    public class ATMRepository : IATMRepository
    {

        private readonly ATMContext _context;

        public ATMRepository(ATMContext context)
        {
            Customer c = new Customer(Guid.NewGuid(), "F", "L");
            Card d = new Card(Guid.NewGuid(), CardTypes.MasterCard, "1234");
            BankAccount ac = new BankAccount(Guid.NewGuid(), c.Id, d.Id, "A", 3200.87);
            Transaction t = new Transaction(Guid.NewGuid(), ac.Id, 50);
            _context = context;
            if (_context.BankAccounts.Count() == 0)
            {
                _context.Customers.Add(c);
                _context.Cards.Add(d);
                _context.BankAccounts.Add(ac);
                _context.Transactions.Add(t);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<BankAccount>> BrowseAnyc()
            => await _context.BankAccounts.ToListAsync();

        public async Task<BankAccount> GetAsync(Guid id)
            => await _context.BankAccounts.SingleOrDefaultAsync(x => x.Id == id);
        
    }
}
