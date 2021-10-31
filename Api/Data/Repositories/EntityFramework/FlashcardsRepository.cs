using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Repositories.Abstract;

namespace Api.Repositories.EntityFramework
{
    public class FlashcardsRepository:IFlashcardsRepository
    {
        private readonly FlashcardsDbContext _dbContext;

        public FlashcardsRepository(FlashcardsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<Flashcard>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Flashcard?> GetByKeyAsync(long key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> AddAsync(Flashcard entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Flashcard entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteByKeyAsync(long key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}