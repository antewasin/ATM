using ATM.Core.IRepository;
using ATM.Services.Dto.Transaction;
using AutoMapper;
using ATM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ATM.Services.Commands.Transaction;
using ATM.Services.Commands.Card;

namespace ATM.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<TransactionDto>> GetAsync() 
        {
            var list = await _repository.BrowseAsync();
            return _mapper.Map<ICollection<TransactionDto>>(list);
        }

        public async Task<TransactionDto> GetAsync(Guid id)
        {
            ATM.Core.Domain.Transaction transaction = await _repository.Get(id);
            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task AddTransction(DoTransaction comment)
        {
            ATM.Core.Domain.Transaction transaction = new ATM.Core.Domain.Transaction(Guid.NewGuid(), comment.BankAccountId, comment.Amount);
            await _repository.AddTransction(transaction);
        }

       
    }
}
