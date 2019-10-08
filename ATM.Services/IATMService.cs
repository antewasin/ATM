using ATM.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services
{
    public interface IATMService
    {
        Task<ICollection<BankAccountDto>> BrowseAnyc();
        Task<BankAccountDto> GetAsync(Guid id);
    }
}
