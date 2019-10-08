using ATM.Core.Domain;
using ATM.Services.Commands.Card;
using ATM.Services.Dto.Card;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services
{
    public interface ICardService
    {
        Task<CardDto> GetPINAsync(Guid id);
        Task<IEnumerable<CardDto>> Get();
        Task ChangePIN(ChangePIN command);
    }
}
