using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repositories.Abstract;
using Api.Repositories.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlashcardsController : ControllerBase
    {
        private readonly IFlashcardsRepository _flashcardsRepository;
        private readonly IDecksRepository _decksRepository;

        public FlashcardsController(IFlashcardsRepository flashcardsRepository, IDecksRepository decksRepository)
        {
            _flashcardsRepository = flashcardsRepository;
            _decksRepository = decksRepository;
        }

        [HttpGet("getAvailableDecks")]
        public async Task<IEnumerable<Deck>> GetAvailableDecks() => 
            await _decksRepository.GetAsync();

        [HttpGet("getFlashcardsInDeck")]
        public async Task<IEnumerable<Flashcard>> GetFlashcardsInDeck([FromQuery] string deckName) =>
            await _flashcardsRepository.GetFlashcardsInDeckAsync(deckName);

        [HttpGet("getShuffledNumberOfNotMemorizedFlashcardsInDeck")]
        public async Task<IEnumerable<Flashcard>> GetFlashcardsInDeck([FromQuery] string deckName, [FromQuery] int numberOfFlashcards) =>
            (await _flashcardsRepository.GetFlashcardsInDeckAsync(deckName))
            .Where(flashcard => !flashcard.WasMemorized)
            .OrderBy(_ => Guid.NewGuid())
            .Take(numberOfFlashcards);

        [HttpPut("updateFlashcard")]
        public async Task<bool> UpdateFlashcard([FromQuery] Flashcard flashcard) =>
            await _flashcardsRepository.UpdateAsync(flashcard);

        [HttpPost("createNewDeck")]
        public async Task<IActionResult> CreateNewDeck([FromQuery] string deckName, [FromQuery]IEnumerable<Flashcard> flashcards)
        {
            if (await _flashcardsRepository.AddRangeAsync(flashcards))
            {
                if (await _decksRepository.AddAsync(new Deck() {Name = deckName, Flashcards = flashcards.ToList()}))
                    return Ok("Deck successfully created");
                else
                    return BadRequest("Deck was not added");
            }
            else
            {
                return BadRequest("Flashcards were not added");
            }
        }
    }
}