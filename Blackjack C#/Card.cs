using System;

namespace Blackjack
{
    public class Card
    {

        public enum Suit { Clubs, Diamonds, Hearts, Spades }

        public Suit suit;
        public int rank;

        public Card(Suit suit, int rank)
        {
            this.rank = rank;
            this.suit = suit;
        }

        //func doesn't return any value
        public void desc()
        {
            if (rank == 1)
                Console.WriteLine($"Ace of {suit}");
            else if (rank == 11)
                Console.WriteLine($"Jack of {suit}");
            else if (rank == 12)
                Console.WriteLine($"Queen of {suit}");
            else if (rank == 13)
                Console.WriteLine($"King of {suit}");
            else
                Console.WriteLine($"{rank} of {suit}");
        }
    }
}