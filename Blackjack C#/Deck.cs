using System;
namespace Blackjack
{
        public class Deck
    {
        //array
        public Card[] cards = new Card[52];

        public int currentTop = 0;
        public int count = 0;

        public Deck()
        {
            /*Looping through the elements in the Card[] array*/
            //Going through suit
            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
            {
                //Going through rank
                for (int r = 1; r <= 13; r++)
                {
                    Card card = new Card(r, s);
                    cards[count] = card;
                    count += 1;
                }
            }
        }

        //Shuffeling the cards first, getting the random number;
		//then dealing them to the player and dealer, adding cards to player and dealer.

        //Shuffling
        public Card[] Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Length; i++)
            {
                int randInd = rand.Next(0, 51);
                Card cardSwitch = cards[i];     // a -> i
                cards[i] = cards[randInd];      // i -> t
                cards[randInd] = cardSwitch;    // t -> a
            }
            return cards;
        }

        //Dealing. Every time Deal() is called, a card's returned
        public Card Deal()
        {
            Card card = cards[currentTop];
            currentTop += 1;

            if (currentTop > 51)
            {
                currentTop = 0;
                cards = Shuffle();
            }
            return card;
        }
    }
}
