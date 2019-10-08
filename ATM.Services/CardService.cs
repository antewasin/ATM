using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ATM.Core.Domain;
using ATM.Core.IRepository;
using ATM.Services.Commands.Card;
using ATM.Services.Dto.Card;
using AutoMapper;

namespace ATM.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CardDto> GetPINAsync(Guid id)
        {
            Card card = await _repository.GetPINAsync(id);

            //by hand
            //CardDto cardDto = new CardDto() { Id = d.Id, PIN = d.PIN, Type = d.Type };
            return _mapper.Map<CardDto>(card);
        }
        public async Task<IEnumerable<CardDto>> Get()
        {

            var list = await _repository.Get();
            return _mapper.Map<IEnumerable<CardDto>>(list);

            /*
            List<CardDto> listCard = new List<CardDto>();
            var list = await _repository.Get();
            foreach (var i in list)
            {
                listCard.Add(new CardDto() { Id = i.Id, PIN = i.PIN, Type = i.Type });
            }
            return listCard;
            */
        }

        public async Task ChangePIN(ChangePIN command)
        {
            //get card with old pin
            //Card c = await _repository.GetPINAsync(command.Id);
            //create the same card with new pin
            Card newCard = new Card(command.Id, command.Type, command.PIN);
            await _repository.ChangePIN(newCard);
        }

    }
}
