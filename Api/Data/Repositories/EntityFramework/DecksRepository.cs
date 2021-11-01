using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories.Abstract;

namespace Api.Repositories.EntityFramework
{
    public class DecksRepository: IDecksRepository
    {
        private readonly FlashcardsDbContext _dbContext;
        public DecksRepository(FlashcardsDbContext dbContext) => 
            _dbContext = dbContext;
        public async Task<IEnumerable<Deck>> GetAsync() => _dbContext.Decks.ToList();

            public async Task<bool> AddAsync(Deck deck)
        {
            await _dbContext.AddAsync(deck);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        
    }
}