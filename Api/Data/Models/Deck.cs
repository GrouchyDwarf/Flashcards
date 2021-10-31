using System;
using System.Collections.Generic;

#nullable disable

namespace Api
{
    public partial class Deck
    {
        public Deck()
        {
            Flashcards = new HashSet<Flashcard>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Flashcard> Flashcards { get; set; }
    }
}
