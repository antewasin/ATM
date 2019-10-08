using ATM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Core.IRepository
{
    public interface IATMRepository
    {
        Task<IEnumerable<BankAccount>> BrowseAnyc();
        Task<BankAccount> GetAsync(Guid id);
    }
}
