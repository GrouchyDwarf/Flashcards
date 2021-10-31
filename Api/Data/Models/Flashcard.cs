using System;
using System.Collections.Generic;

#nullable disable

namespace Api
{
    public partial class Flashcard
    {
        public long Id { get; set; }
        public string Phrase { get; set; }
        public string Translation { get; set; }
        public long DeckId { get; set; }
        public bool WasMemorized { get; set; }

        public virtual Deck Deck { get; set; }
    }
}
