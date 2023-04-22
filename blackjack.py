import random

suits = ("Spades", "Clubs", "Hearts", "Diamonds")
ranks = {"A": 1, "2": 2, "3": 3, "4": 4, "5": 5, "6": 6, "7": 7, "8": 8, "9": 9, "10": 10, "J": 11, "Q": 12,"K": 13}

play_again = True

# CLASS DEFINTIONS:
class Card:
    def __init__(self, suit, rank):
        self.suit = suit
        self.rank = rank
 
    def __str__(self):
        return self.rank + ' of ' + self.suit


class Deck:
    def __init__(self):
        self.deck = []  # start with an empty list
        for suit in suits:
            for rank in ranks.keys():
                self.deck.append(Card(suit, rank))

    def shuffle(self):
        random.shuffle(self.deck)

    def deal(self):
        single_card = self.deck.pop()
        return single_card


class Hand:
    def __init__(self):
        self.cards = []  # start with an empty list as we did in the Deck class
        self.point = 0  # start at 0 point

    def add_card(self, card):
        self.cards.append(card)
        self.point += ranks[card.rank]

def show_all_cards(player, dealer):
    print("\nPlayer's Card:", *player.cards, sep="\n ")
    print("Player's Points =", player.point)
    print("\nDealer's Card:", *dealer.cards, sep="\n ")
    print("Dealer's Points =", dealer.point)

while True:
    print('\n-----    The play is starting    -----')

    # Create & shuffle the deck, deal two cards to each player
    deck = Deck()
    deck.shuffle()

    player_hand = Hand()
    dealer_hand = Hand()

    for i in range(2): #Both the player & dealer have 2 cards at the beginning.
        player_hand.add_card(deck.deal())
        dealer_hand.add_card(deck.deal())

    # Showing the player's and dealer's cards:
    show_all_cards(player_hand, dealer_hand)

    player_choice = input('\nDo you want another card? [y/Y]: ')

    """GAME LOGIC"""

    while (player_choice == 'y' or player_choice ==' Y'):
        player_hand.add_card(deck.deal())
        dealer_hand.add_card(deck.deal())
        show_all_cards(player_hand, dealer_hand)
        if player_hand.point > 21:
            break
        elif player_hand.point == 21:
            break
        elif player_hand.point < 21:
            player_choice = input('\nDo you want another card? [y/Y]: ')

    playing = False

    if player_hand.point > 21:
        if player_hand.point == dealer_hand:
            print("\n DEALER'S POINTS: ", dealer_hand.point, "\n PLAYER'S POINTS:\t", player_hand.point)
        elif player_hand.point > dealer_hand.point:
            print("\n DEALER WIN: ", dealer_hand.point, "\n YOU LOSE:\t", player_hand.point)
        else:
            print("\n DEALER LOSE: ", dealer_hand.point, "\n YOU WIN:\t", player_hand.point)
        # print("\n DEALER WIN: ", dealer_hand.point, "\n YOU LOSE:\t", player_hand.point)
    elif player_hand.point == 21 and dealer_hand.point==21:
        print("\n IT'S A TIE")
        print("\n DEALER'S POINTS: ", dealer_hand.point, " PLAYER'S POINTS: ", player_hand.point)
    else:
        while dealer_hand.point < 16:
            dealer_hand.add_card(deck.deal())
        
        if dealer_hand.point == 21:
            show_all_cards(player_hand, dealer_hand)
            print('\n DEALER WIN!!!')
        elif dealer_hand.point > 21:
            if dealer_hand.point > player_hand.point:
                print("\n DEALER LOSE: ", dealer_hand.point, "\n YOU WIN:\t", player_hand.point)
            else:
                print("\n DEALER WIN: ", dealer_hand.point, "\n YOU LOSE:\t", player_hand.point)
        else:
            if dealer_hand.point == player_hand.point:
                print("\n IT'S A TIE")
            elif dealer_hand.point > player_hand.point:
                print("\n DEALER WIN: ", dealer_hand.point, "\n YOU LOSE:\t", player_hand.point)
            else:
                print("\n DEALER LOSE: ", dealer_hand.point, "\n YOU WIN:\t", player_hand.point)

    # Asking if the player want to replay
    new_game = input("\nEnter 'y' or 'Y' to play again, else to stop: ")
    
    if (new_game == 'y' or new_game == 'Y'):
        play_again = True
        continue
    else:
        play_again = False

    print('\nThank you for playing!\n-----     Bye!    -----\n')
    break