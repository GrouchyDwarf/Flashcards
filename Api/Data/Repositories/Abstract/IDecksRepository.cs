using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories.Abstract
{
    public interface IDecksRepository
    {
        Task<IEnumerable<Deck>> GetAsync();
        Task<bool> AddAsync(Deck deck);
    }
}