using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Transactions;
using System.Xml.Schema;

namespace algorithms
{
    public class DeckOfCards
    {
        public static int RandomInRange(int min, int max)
        {
            if (min > max)
            {
                var temp = min;
                min = max;
                max = temp;
            }
            Random random = new Random();
            return random.Next(min, max);
        }
        public enum Suit
        {
            Club = 0, Diamond = 1, Heart = 2, Spade = 3
        }

        public abstract class Card
        {
            private bool available = true;
            protected int faceValue;
            protected Suit suit;

            public Card(int c, Suit s)
            {
                suit = s;
                faceValue = c;
            }

            public abstract int value();

            public Suit GetSuit()
            {
                return suit;
            }

            public bool IsAvailable()
            {
                return available;
            }

            public void MarkAvailable()
            {
                available = true;
            }

            public void MakeUnAvailable()
            {
                available = false;
            }

            public void Print()
            {
                String[] faceValues = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
                Console.Write(faceValues[faceValue - 1]);
                switch (suit)
                {
                    case Suit.Club:
                        Console.Write("C");
                        break;
                    case Suit.Heart:
                        Console.Write("H");
                        break;
                    case Suit.Diamond:
                        Console.Write("D");
                        break;
                    case Suit.Spade:
                        Console.Write("S");
                        break;
                }
                Console.Write(" ");
            }


        }

        public class Deck<T> where T : Card
        {
            private List<T> cards;
            private int dealtIndex = 0;

            public Deck()
            {

            }

            public void setDeckOfCards(List<T> deckofCards)
            {
                cards = deckofCards;
            }

            public void Shuffle()
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    int j = RandomInRange(i, cards.Count - i);
                    T card1 = cards[i];
                    cards[i] = cards[j];
                    cards[j] = card1;
                }
            }

            public int RemainingCards()
            {
                return cards.Count - dealtIndex;
            }

            public T[] Deal(int number)
            {
                if (RemainingCards() < number)
                {
                    return null;
                }

                T[] hand = (T[])new Card[number];
                int count = 0;
                while (count < number)
                {
                    T card = DealCard();
                    if (card != null)
                    {
                        hand[count] = card;
                        count++;
                    }
                }

                return hand;
            }

            public T DealCard()
            {
                if (RemainingCards() == 0)
                {
                    return null;
                }

                T card = cards[dealtIndex];
                card.MakeUnAvailable();
                dealtIndex++;
                return card;
            }

            public void Print()
            {
                foreach (var card in cards)
                {
                    card.Print();
                }
                Console.WriteLine(" ");
            }


        }

        public class Hand<T> where T : Card
        {
            public List<T> cards = new List<T>();

            public int Score()
            {
                int score = 0;

                foreach (var card in cards)
                {
                    score = score + card.value();
                }

                return score;
            }

            public void AddCard(T card)
            {
                cards.Add(card);
            }

            public void Print()
            {
                foreach (var card in cards)
                {
                    card.Print();
                }
            }

        }

        public class BlackJackCard : Card
        {
            public BlackJackCard(int c, Suit s) : base(c, s)
            {
            }

            public override int value()
            {
                if (isAce())
                { // Ace
                    return 1;
                }
                else if (isFaceCard())
                { // Face card
                    return 10;
                }
                else
                { // Number card
                    return faceValue;
                }
            }

            public bool isAce()
            {
                return faceValue == 1;
            }

            public int minValue()
            {
                if (isAce())
                { // Ace
                    return 1;
                }
                else
                {
                    return value();
                }
            }

            public int maxValue()
            {
                if (isAce())
                { // Ace
                    return 11;
                }
                else
                {
                    return value();
                }
            }

            public bool isFaceCard()
            {
                return faceValue >= 11 && faceValue <= 13;
            }
        }

        public class BlackJackHand : Hand<BlackJackCard>
        {
            public int score()
            {
                List<int> scores = PossibleScores();

                int maxUnder = int.MinValue;
                int minOver = int.MaxValue;
                foreach (var score in scores)
                {
                    if (score > 21 && score < minOver)
                    {
                        minOver = score;
                    }
                    else if (score <= 21 && score > maxUnder)
                    {
                        maxUnder = score;
                    }
                }
                return maxUnder == int.MinValue ? minOver : maxUnder;
            }

            private List<int> PossibleScores()
            {
                List<int> scores = new List<int>();
                if (cards.Count == 0)
                {
                    return scores;
                }

                foreach (var card in cards)
                {
                    AddCardToScoreList(card, scores);

                }
                return scores;
            }

            private void AddCardToScoreList(BlackJackCard card, List<int> scores)
            {
                if (scores.Count == 0)
                {
                    scores.Add(0);
                }
                int length = scores.Count;
                for (int i = 0; i < length; i++)
                {
                    int score = scores[i];
                    scores[i] = score + card.minValue();
                    if (card.minValue() != card.maxValue())
                    {
                        scores.Add(score + card.maxValue());
                    }
                }
            }

            public bool busted()
            {
                return score() > 21;
            }

            public bool is21()
            {
                return score() == 21;
            }

            public bool isBlackJack()
            {
                if (cards.Count != 2)
                {
                    return false;
                }
                BlackJackCard first = cards[0];
                BlackJackCard second = cards[1];
                return (first.isAce() && second.isFaceCard()) || (second.isAce() && first.isFaceCard());
            }
        }

        public class BlackJackGameAutomator
        {
            private Deck<BlackJackCard> deck;
            private BlackJackHand[] hands;
            private int HIT_UNTIL = 16;

            public BlackJackGameAutomator(int players)
            {
                hands = new BlackJackHand[players];
                for (int i = 0; i < players; i++)
                {
                    hands[i] = new BlackJackHand();
                }

            }

            public bool DealInitial()
            {
                foreach (var hand in hands)
                {
                    var card1 = deck.DealCard();
                    var card2 = deck.DealCard();
                    if (card1 == null || card2 == null)
                    {
                        return false;
                    }
                    hand.AddCard(card1);
                    hand.AddCard(card2);
                }

                return true;
            }

            public List<int> GetBlackJacks()
            {
                List<int> winners = new List<int>();
                for (int i = 0; i < hands.Length; i++)
                {
                    if (hands[i].isBlackJack())
                    {
                        winners.Add(i);
                    }
                }

                return winners;
            }

            public bool PlayHand(int i)
            {
                BlackJackHand hand = hands[i];
                return PlayHand(hand);
            }

            public bool PlayHand(BlackJackHand hand)
            {
                while (hand.score() < HIT_UNTIL)
                {
                    BlackJackCard card = deck.DealCard();
                    if (card == null)
                    {
                        return false;
                    }
                    hand.AddCard(card);
                }
                return true;
            }

            public bool PlayAllHands()
            {
                foreach (var hand in hands)
                {
                    if (!PlayHand(hand))
                    {
                        return false;
                    }
                }
                return true;
            }

            public List<int> GetWinners()
            {
                List<int> winners = new List<int>();
                int winningScore = 0;
                for (int i = 0; i < hands.Length; i++)
                {
                    BlackJackHand hand = hands[i];
                    if (!hand.busted())
                    {
                        if (hand.score() > winningScore)
                        {
                            winningScore = hand.score();
                            winners.Clear();
                            winners.Add(i);
                        }
                        else if (hand.score() == winningScore)
                        {
                            winners.Add(i);
                        }
                    }
                }
                return winners;
            }

            public void InitializeDeck()
            {
                List<BlackJackCard> cards = new List<BlackJackCard>();
                for (int i = 1; i <= 13; i++)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        Suit suit = (Suit)j;
                        BlackJackCard card = new BlackJackCard(i, suit);
                        cards.Add(card);
                    }
                }

                deck = new Deck<BlackJackCard>();
                deck.setDeckOfCards(cards);
                deck.Shuffle();
            }

            public void printHandsAndScore()
            {
                for (int i = 0; i < hands.Length; i++)
                {
                    Console.Write("Hand " + i + " (" + hands[i].score() + "): ");
                    hands[i].Print();
                    Console.Write("");
                }
            }

        }
        public void Run()
        {
            int numHands = 5;

            BlackJackGameAutomator automator = new BlackJackGameAutomator(numHands);
            automator.InitializeDeck();
            bool success = automator.DealInitial();
            if (!success)
            {
                Console.WriteLine("Error. Out of cards.");
            }
            else
            {
                Console.WriteLine("-- Initial --");
                automator.printHandsAndScore();
                List<int> blackjacks = automator.GetBlackJacks();
                if (blackjacks.Count > 0)
                {
                    Console.Write("Blackjack at ");
                    foreach (int i in blackjacks)
                    {
                        Console.Write(i + ", ");
                    }
                    Console.WriteLine("");
                }
                else
                {
                    success = automator.PlayAllHands();
                    if (!success)
                    {
                        Console.Write("Error. Out of cards.");
                    }
                    else
                    {
                        Console.WriteLine("\n-- Completed Game --");
                        automator.printHandsAndScore();
                        List<int> winners = automator.GetWinners();
                        if (winners.Count > 0)
                        {
                            Console.Write("Winners: ");
                            foreach (int i in winners)
                            {
                                Console.Write(i + ", ");
                            }
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Draw. All players have busted.");
                        }
                    }
                }
            }
        }
    }
}

