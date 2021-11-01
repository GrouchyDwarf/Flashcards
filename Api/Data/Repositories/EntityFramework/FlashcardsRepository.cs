using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.EntityFramework
{
    public class FlashcardsRepository:IFlashcardsRepository
    {
        private readonly FlashcardsDbContext _dbContext;

        public FlashcardsRepository(FlashcardsDbContext dbContext) => 
            _dbContext = dbContext;
        
        public async Task<bool> AddRangeAsync(IEnumerable<Flashcard> flashcards)
        {
            await _dbContext.AddRangeAsync(flashcards);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Flashcard flashcard)
        {
            _dbContext.Entry(flashcard).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Flashcard>> GetFlashcardsInDeckAsync(string deckName) =>
            _dbContext.Flashcards.Where(flashcard => flashcard.Deck.Name == deckName).ToList();
        
    }
}