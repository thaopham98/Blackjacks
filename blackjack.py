import random 

"""
Define card suits and ranks
"""
suits = ("Spades", "Clubs", "Hearts", "Diamonds")
ranks = {
        "A": 1, "2": 2, "3": 3, "4": 4, "5": 5, "6": 6, "7": 7, 
        "8": 8, "9": 9, "10": 10, "J": 10, "Q": 10,"K": 10
         }


# CLASS DEFINTIONS:
"""
Represents a single playing card with a suit and rank
"""
class Card:
    def __init__(self, suit, rank): # creates a `card` object with `suit` and `rank` as its attributes/info
        self.suit = suit
        self.rank = rank
 
    def __str__(self):
        return f'{self.rank} of {self.suit}' #displays/returns the card

"""
Represents a deck of 52 playing cards, allowing shuffling and dealing
"""
class Deck:
    def __init__(self):  
        ''' Creates a `deck` object: 
            - Iterate over all suits
            - For each suit, iterate over all ranks
            - Create a `card` object using the current `suit` and `ranks`
            - Add the `card` object to the list `self.deck`
        '''
        self.deck = [Card(suit, rank) for suit in suits for rank in ranks]  # start with an empty list

    """ Shuffles the deck randomly """
    def shuffle(self): 
        random.shuffle(self.deck)

    """ Removes and returns the top card from the deck """
    def deal(self):
        single_card = self.deck.pop()
        return single_card

"""
Represents a player's hand, keeping track of cards
    and their total point value
"""
class Hand:
    def __init__(self):
        self.cards = []  # Hold Card object (by start with an empty list as we did in the Deck class)
        self.points = 0  # Tracks total point (by start at 0 point)

    """ Adds a card to the hand and updates the total points """
    def add_card(self, card):
        if card:
            self.cards.append(card) 
            self.points += ranks[card.rank]
    
    def __str__(self):
        return ", ".join(str(card) for card in self.cards) + f" (Points: {self.points})"


""" Displays all the player's and dealer's cards along with their points """
def show_all_cards(player, dealer):
    print(f"\nPlayer's Cards:\n {player}\n")
    print(f"Dealer's Cards:\n {dealer}\n")


"""     MAIN GAME LOOP      """
while True:
    print('\n-----    The play is starting    -----')

    """ Create & shuffle the deck, deal two cards to each player """
    deck = Deck()
    deck.shuffle()

    player_hand = Hand()
    dealer_hand = Hand()

    """ Deal 2 cards to each player """
    for i in range(2): #Both the player & dealer have 2 cards at the beginning.
        player_hand.add_card(deck.deal())
        dealer_hand.add_card(deck.deal())

    show_all_cards(player_hand, dealer_hand) # Showing the player's and dealer's cards:

    """
    Player's turn: 
    while the player's poins lesser than 21, 
    ask the player if they want to another card or not
    """    
    while player_hand.points < 21 and input('\nDo you want another card? [y/Y]: ').lower() == 'y':
        player_hand.add_card(deck.deal()) # add another card if player answers yes
        show_all_cards(player_hand, dealer_hand) # display the current cards of both players
    
    # Determine winner
    if player_hand.points > 21:
        print("\nYou Busted! Dealer Wins.")
    else: # the dealer only get another card if the player answer NO
        while dealer_hand.points < 16: # if dealer only has lesser than 16 points,
            dealer_hand.add_card(deck.deal()) # dealder gets a card
        
        show_all_cards(player_hand, dealer_hand) # displays both players' cards and points
        
        if dealer_hand.points > 21:
            print("\nDealer Busted! You Win.")
        elif dealer_hand.points > player_hand.points:
            print("\nDealer Wins!")
        elif dealer_hand.points < player_hand.points:
            print("\nYou Win!")
        else:
            print("\nIt's a Tie!")
    
    # Ask if the player wants to play again
    if input("\nEnter 'y' to play again, else to stop: ").lower() != 'y':
        print('\nThank you for playing!\n-----     Bye!    -----\n')
        break