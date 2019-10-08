using ATM.Services.Commands.Card;
using ATM.Services.Commands.Transaction;
using ATM.Services.Dto.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services.Transaction
{
    public interface ITransactionService
    {
        Task<TransactionDto> GetAsync(Guid id);
        Task<ICollection<TransactionDto>> GetAsync();
        Task AddTransction(DoTransaction command);
       
    }
}
