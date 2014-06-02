using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerModel.DomainObjects
{
    #region Data Types
    public enum Suits
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Faces
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }

    public struct Card
    {
        public Suits Suit;
        public Faces Face;

        public Card(Suits suit, Faces face)
        {
            Suit = suit;
            Face = face;
        }
    }

    public class Hand
    {
        private List<Card> sortedHand;
        private Dictionary<Faces, int> histogram;

        public void AddCard(Card newCard)
        {
            if (histogram.ContainsKey(newCard.Face))
            {
                histogram[newCard.Face] += 1;
            }
            else
            {
                histogram.Add(newCard.Face, 1);
            }

            sortedHand.Add(newCard);
            sortedHand = (from c in sortedHand orderby c.Face ascending select c).ToList<Card>();
        }

        public Hand()
        {
            histogram = new Dictionary<Faces, int>();
            sortedHand = new List<Card>();
        }

        public List<Card> Cards { get { return sortedHand; } }
        public Dictionary<Faces, int> Histogram { get { return histogram; } }

        public Card? HighCard 
        { 
            get 
            {
                if (sortedHand.Count() > 0)
                {
                    return sortedHand.Last();
                }

                return null;
            } 
        }
        
    }
    #endregion
    public class ScoreModel
    {

          
    }

    public interface IHand
    {
        bool HasThisHand(Hand hand);
    }

    public class StraightFlush : IHand
    {
        public bool HasThisHand(Hand hand)
        {
            Flush flush = new Flush();
            Straight straight = new Straight();

            return flush.HasThisHand(hand) && straight.HasThisHand(hand);
        }
    }

    public class Flush : IHand
    {

        public bool HasThisHand(Hand hand)
        {
            var x = from c in hand.Cards where c.Suit != hand.Cards[0].Suit select c;

            if (x.Count() > 0)
                return false;

            return true;
        }
    }

    public class Straight : IHand
    {

        public bool HasThisHand(Hand hand)
        {
            if (hand.Cards[0].Face == hand.Cards[1].Face - 1
                && hand.Cards[1].Face == hand.Cards[2].Face - 1
                && hand.Cards[2].Face == hand.Cards[3].Face - 1
                && hand.Cards[3].Face == hand.Cards[4].Face - 1)
            {
                return true;
            }

            return false;
        }
    }

    public class ThreeOfAKind : IHand
    {
        public bool HasThisHand(Hand hand)
        {
            foreach (Faces face in hand.Histogram.Keys)
            {
                if (hand.Histogram[face] == 3)
                    return true;
            }

            return false;
        }
    }

    public class TwoPair : IHand
    {

        public bool HasThisHand(Hand hand)
        {
            int pairCount = 0;
            foreach (Faces face in hand.Histogram.Keys)
            {
                if (hand.Histogram[face] == 2)
                    pairCount++;
            }

            return pairCount == 2;
        }
    }

    public class OnePair : IHand
    {

        public bool HasThisHand(Hand hand)
        {
            int pairCount = 0;
            foreach (Faces face in hand.Histogram.Keys)
            {
                if (hand.Histogram[face] == 2)
                    pairCount++;
            }

            return pairCount == 1;
        }
    }

    public class FullHouse : IHand
    {
        public bool HasThisHand(Hand hand)
        {
            ThreeOfAKind threeOfAKind = new ThreeOfAKind();
            OnePair onePair = new OnePair();

            return threeOfAKind.HasThisHand(hand) && onePair.HasThisHand(hand);
        }
    }

}