using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Repositories.Abstract;

namespace Api.Repositories.EntityFramework
{
    public class DecksRepository: IDecksRepository
    {
        public async Task<IEnumerable<Deck>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Deck?> GetByKeyAsync(long key)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> AddAsync(Deck entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Deck entity)
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