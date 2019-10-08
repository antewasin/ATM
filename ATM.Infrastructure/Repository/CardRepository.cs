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
    public class CardRepository : ICardRepository
    {
        private readonly ATMContext _context;

        public CardRepository(ATMContext context)
        {
            _context = context;
        }

        public async Task<Card> GetPINAsync(Guid id)
        {
            Card t = await _context.Cards.SingleOrDefaultAsync(x => x.Id == id);
            return t;
        }
        public async Task<IEnumerable<Card>> Get()
            => await _context.Cards.ToListAsync();

        public Task ChangePIN(Card card, Guid AccountId)
        {
            throw new NotImplementedException();
        }

        public async Task ChangePIN(Card card)
        {
            _context.Update(card);
            await _context.SaveChangesAsync();
        }
    }
}
