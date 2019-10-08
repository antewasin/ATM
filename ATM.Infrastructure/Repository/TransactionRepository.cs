using ATM.Core.Domain;
using ATM.Core.IRepository;
using ATM.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ATMContext _context;

        public TransactionRepository(ATMContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Transaction>> BrowseAsync()
            => await _context.Transactions.ToListAsync();

        public async Task<Transaction> Get(Guid id)
            => await _context.Transactions.SingleOrDefaultAsync(x => x.Id == id);

        public async Task AddTransction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            Debug.WriteLine(transaction.BankAccountId);
            BankAccount ba = await _context.BankAccounts.SingleOrDefaultAsync(x => x.Id == transaction.BankAccountId);
            ba.changeBalance(transaction.Amount);
            _context.SaveChanges();
            await Task.CompletedTask;
        }

       
    }
}
