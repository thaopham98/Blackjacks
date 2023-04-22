//
//  main.swift
//  exercise_2
//
//  Created by PPHAM1 on 9/3/21.
//  Copyright © 2021 Thao Pham. All rights reserved.
//

import Foundation

/*MARK: class Card*/
class Card {
    enum Suit: CaseIterable
    {
        case Clubs
        case Diamonds
        case Hearts
        case Spades
    }
    
    var rank:Int
    var suit:Suit
    
    var desc:String
    {
        get{
            /*
             if rank == 1{
             return "Ace of \(suit)"
             } else if rank == 11{
             return "Jack of \(suit)"
             } else if rank == 12{
             return "Queen of \(suit)"
             } else if rank == 13{
             return "King of \(suit)"
             } else{
             return "\(rank) of \(suit)"
             }*/
            switch rank {
            case 1:
                return "Ace of \(suit)"
            case 11:
                return "Jack of \(suit)"
            case 12:
                return "Queen of \(suit)"
            case 13:
                return "King of \(suit)"
            default:
                return "\(rank) of \(suit)"
            }
        }
    }
    
    init(rank: Int, suit:Suit){
        self.rank = rank
        self.suit = suit
    }
}

/*MARK: class Deck*/
class Deck
{
    var cards:[Card] = []   // define an array, the type of the array is empty at the beginning
    var currentTop:Int = 0
    
    init (){                // the init function of the Deck
        for s in Card.Suit.allCases // use for loop to go over very Suit(s)
        {
            for r in 1...13
            {
                let card = Card(rank: r, suit: s ) // creating the card
                cards.append(card)                 // adding the card to the array
            }
        }
    }
    
    func shuffle(){
        cards.shuffle()
    }
    
    /*Every time calling deal(), it'll return a card*/
    func deal() -> Card
    {
        let card = cards[currentTop]
        currentTop += 1
        if currentTop > 52
        {
            currentTop = 0
            cards.shuffle()
        }
        return card
    }
}

/*MARK: showCardsAndPoints() */
func showCardsAndPoints(cards:[Card])
{
    print("----------------------------------")
    var sumOfPoints = 0
    for card in cards{
        print("\(card.desc)")
        sumOfPoints += card.rank
    }
    print("\nThe total points are \(sumOfPoints).")
}

/*MARK: sum() */
func sum(cards:[Card]) -> Int
{
    var sumOfPoints = 0
    for card in cards{
        sumOfPoints += card.rank
    }
    return sumOfPoints
}

let deck = Deck() //creating a deck
//print(deck.cards[0].desc)
//print(deck.cards[51].desc)
var playAgain = true

var playerCards:[Card] = []
var dealerCards:[Card] = []

//var currentTopCard:Int = 0

/*MARK: while-loop playAgain */
while playAgain
{
    /*Game Logic*/
    deck.shuffle()
    playerCards.removeAll()
    dealerCards.removeAll()
    deck.currentTop = 0
    
    dealerCards.append(deck.deal())
    dealerCards.append(deck.deal())
    
    playerCards.append(deck.deal())
    playerCards.append(deck.deal())
    
    //currentTopCard = 4
    
    /*Player's Round*/
    print("Player Side:")
    showCardsAndPoints(cards:playerCards)
    
    print("\nDo you want to get another card? (y/n): ")
    
    var userAnswer = readLine()
    
    while userAnswer == "y"
    {
        playerCards.append(deck.deal())
        showCardsAndPoints(cards: playerCards)
        print("\nDo you want to get another card? (y/n): ")
        userAnswer = readLine()
    }
        print("Player Side: ")
        showCardsAndPoints(cards:playerCards)
    
    if sum(cards: playerCards) == 21
    {
        print("You WIN!!!\n")
    }
    else if sum(cards: playerCards) < 21
    {
        print("You LOSE!!!\n")
    }
    else // playerCars > 21
    {
        /*Dealer's Rounds*/
        print("Dealer Side: ")
        showCardsAndPoints(cards: dealerCards)
        while sum(cards: dealerCards) < 16
        {
            dealerCards.append(deck.deal())
            print("Dealer Side: ")
            showCardsAndPoints(cards: dealerCards)
        }
        
        if sum(cards: dealerCards) == 21
        {
            print("You LOSE! Dealer WIN!!!\n")
        }
        else if sum(cards: dealerCards) > 21
        {
            print("Dealer LOSE! You WIN!!!\n")
        }
        else
        {
            if sum(cards: dealerCards) > sum(cards: playerCards)
            {
                print("Dealer: \(sum(cards: dealerCards)), You: \(sum(cards: playerCards)). You LOSE!!!\n")
            }
            else if sum(cards: dealerCards) < sum(cards: playerCards)
            {
                print("Dealer: \(sum(cards: dealerCards)), You: \(sum(cards: playerCards)). You WIN!!!\n")
            }
            else // Both side are equal
            {
                print("Dealer: \(sum(cards: dealerCards)), You: \(sum(cards: playerCards)). DRAW!!!\n")
            }
        }
    }
    
    print("\nDo you want to play again? (y/n): ")
    let userInput = readLine()
    if userInput != "y"
    {
        print("\nBye!\n")
        playAgain = false
    }
}
