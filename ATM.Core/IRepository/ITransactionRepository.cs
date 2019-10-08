using ATM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Core.IRepository
{
    public interface ITransactionRepository
    {
        Task<ICollection<Transaction>> BrowseAsync();
        Task<Transaction> Get(Guid id);
        Task AddTransction(Transaction transaction);
 
    }
}
