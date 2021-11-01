using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories.Abstract
{
    public interface IFlashcardsRepository
    {
        Task<bool> AddRangeAsync(IEnumerable<Flashcard> flashcards);
        Task<bool> UpdateAsync(Flashcard flashCard);
        Task<IEnumerable<Flashcard>> GetFlashcardsInDeckAsync(string deckName);

    }
}