using System;
namespace Blackjack
{
    class Points
    {
        //Getting the value of sumpoints = a func returns a value
        public int sum(Card[] cards)
        {
            int sumpoints = 0;
            for (int k = 0; k < cards.Length; k++)
            {
                sumpoints += cards[k].rank;
            }
            return sumpoints; //The value to return
        }

        //NO static && SET public so that we can use this func later.
        public void showCardsAndPoints(Card[] cards)
        {
            Console.WriteLine("----------------------------------");
            int sumPoint = 0;
            if (cards.Length == 2)
            {
                if (cards[0].rank == 1 && cards[1].rank == 10)
                    sumPoint = 21;
                else if (cards[0].rank == 10 && cards[1].rank == 1)
                    sumPoint = 21;
                else
                    sumPoint = cards[0].rank + cards[1].rank;

                cards[0].desc();
                cards[1].desc();
            }
            else
            {
                for (int j = 0; j < cards.Length; j++)
                {
                    cards[j].desc();
                    sumPoint += cards[j].rank;
                }
            }

            Console.WriteLine($"\nThe total points are: {sumPoint}");
        }

        //Adding a new card during the game
        public Card[] addCard(Card[] cards, Card card)
        {
            Card[] cards1 = new Card[cards.Length + 1]; //Adding 1 more card
            int c;
            for (c = 0; c < cards.Length; c++)
                cards1[c] = cards[c];
            cards1[c] = card;
            return cards1;
        }
    }

    class Project
    {

        //public Card[] playerCards;
        //public Card[] dealerCards;

        public static void Main()
        {
            //creating new deck
            Deck deck = new Deck();

            //creating new points
            Points points = new Points();

            bool playAgain = true;

            while (playAgain)
            {
                deck.Shuffle();
                deck.currentTop = 0;

                //No. Since "public" == error
                Card[] playerCards = {};
                Card[] dealerCards = {};

                
                Array.Clear(playerCards, 0, playerCards.Length);
                Array.Clear(dealerCards, 0, dealerCards.Length);

                //Giving/dealing/adding 2 cards to player
                playerCards = points.addCard(playerCards, deck.Deal());
                playerCards = points.addCard(playerCards, deck.Deal());

                //Giving/dealing/adding 2 cards to dealer
                dealerCards = points.addCard(dealerCards, deck.Deal());
                dealerCards = points.addCard(dealerCards, deck.Deal());

                /*PLAYER'S ROUND*/
                Console.WriteLine("--------- Player's Round ---------");
                //Points of the Player:
                points.showCardsAndPoints(playerCards);

                //Ask the player for another card
                Console.WriteLine("\nDo you want another card? y/n");
                string inputOfACard = Console.ReadLine();
                while (inputOfACard == "y" || inputOfACard == "Y")
                {
                    playerCards = points.addCard(playerCards, deck.Deal()); // adding a card
                    //points.showCardsAndPoints(playerCards);
                    Console.WriteLine($"DEALER: {points.sum(dealerCards)}, YOU: {points.sum(playerCards)}."); // show the points
                    points.showCardsAndPoints(playerCards);
                    if (points.sum(playerCards) > 21)
                    {
                        points.showCardsAndPoints(playerCards);
                        break;
                    }
                    else if (points.sum(playerCards) == 21)
                    {
                        points.showCardsAndPoints(playerCards);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Do you want another card? y/n");
                        inputOfACard = Console.ReadLine();
                    }
                }

                if (points.sum(playerCards) == 21)
                {
                    Console.WriteLine("\nYOU WIN!!!");                    
                }
                else if (points.sum(playerCards) > 21)
                {
                    Console.WriteLine("\nBUST! YOU LOSE!!!");

                }
                else if ((playerCards[0].rank == 1 && playerCards[1].rank == 10) || (playerCards[0].rank == 10 && playerCards[1].rank == 1) )
                {
                    Console.WriteLine("\nBLACKJACK! YOU WIN!!!");
                }
                else //When point.sum(playerCards) < 21
                {
                    /*DEALER'S ROUND*/
                    Console.WriteLine("\n\n========= Dealer's Round =========");
                    points.showCardsAndPoints(dealerCards);

                    //Add more card if point of dealerCards < 16
                    while (points.sum(dealerCards) < 16)
                    {
                        dealerCards = points.addCard(dealerCards, deck.Deal());
                        //showing how many point after adding a card.
                        points.showCardsAndPoints(dealerCards);
                    }

                    if (points.sum(dealerCards) == 21)
                    {
                        Console.WriteLine($"DEALER: {points.sum(dealerCards)}, YOU: {points.sum(playerCards)}. \nYOU LOSE!!! DEALER WIN!!!");
                    }
                    else if (points.sum(dealerCards) > 21)
                    {
                        Console.WriteLine($"DEALER: {points.sum(dealerCards)}, YOU: {points.sum(playerCards)}. \nYOU WIN!!! DEALER LOSE!!!");
                    }
                    //else if ((dealerCards[0].rank == 1 && dealerCards[1].rank == 10) || (dealerCards[0].rank == 10 && dealerCards[1].rank == 1))
                    //{
                    //    Console.WriteLine("\nYOU LOSE!!! DEALER WIN!!!");
                    //}
                    else
                    {
                        if (points.sum(dealerCards) > points.sum(playerCards))
                            Console.WriteLine($"DEALER: {points.sum(dealerCards)}, YOU: {points.sum(playerCards)}. \nYOU LOSE!!! DEALER WIN!!!");
                        else if (points.sum(dealerCards) < points.sum(playerCards))
                            Console.WriteLine($"DEALER: {points.sum(dealerCards)}, YOU: {points.sum(playerCards)}. \nYOU WIN!!! DEALER LOSE!!!");
                        //else if (((playerCards[0].rank == 1 && playerCards[1].rank == 10) || (playerCards[0].rank == 10 && playerCards[1].rank == 1)) ==
                        //    ((dealerCards[0].rank == 1 && dealerCards[1].rank == 10) || (dealerCards[0].rank == 10 && dealerCards[1].rank == 1)))
                        //{
                        //    Console.WriteLine("\nDRAW! YOU WIN!!!");
                        //}
                        else
                            Console.WriteLine($"DRAW!!! DEALER: {points.sum(dealerCards)}, YOU: {points.sum(playerCards)} \nYOU WIN!!!");
                    }
                }
                Console.WriteLine("\nDo you want to play again? (y/n)");
                string inputReplay = Console.ReadLine();
                if (inputReplay != "y") //NO "Y"
                {
                    Console.WriteLine("Goodbye!");
                    playAgain = false;  // user enter not y/
                }
                Console.WriteLine("\n\n         NEW ROAND!\n");
            }
        }
    }
}
