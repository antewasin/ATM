using ATM.Core.Domain;
using ATM.Core.IRepository;
using ATM.Services.Dto;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services
{
    public class ATMService : IATMService
    {

        private readonly IATMRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public ATMService(IATMRepository repository, IMemoryCache cache, IMapper mapper)
        {
            _repository = repository;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<ICollection<BankAccountDto>> BrowseAnyc()
        {

            var list = await _repository.BrowseAnyc();
            return _mapper.Map<ICollection<BankAccountDto>>(list);
            /*
            //RĘCZNE MAPOWANIE
            List<BankAccountDto> listBankAccount = new List<BankAccountDto>();
            var list =  await _repository.BrowseAnyc();
            foreach (var i in list)
            {
                listBankAccount.Add(new BankAccountDto() { Id=i.Id, CustomerId=i.CustomerId, CardId=i.CardId, NameAccount=i.NameAccount });
            }
            return listBankAccount;*/
        }

        public async Task<BankAccountDto> GetAsync(Guid id)
        {
            /*// mapowanie; pobieram obiekt z bazy danych i przypisuje do fake obiektu
            BankAccount bankAccount = await _repository.GetAsync(id);
            BankAccountDto bankAccountDto = new BankAccountDto() { Id = bankAccount.Id, CardId = bankAccount.CardId, CustomerId = bankAccount.CustomerId, NameAccount = bankAccount.NameAccount };
            return bankAccountDto;*/

            BankAccount bankAccount = await _repository.GetAsync(id);
            return _mapper.Map<BankAccountDto>(bankAccount);
        }



    }
}
