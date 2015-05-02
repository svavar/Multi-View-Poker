using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PokerModel.DomainObjects
{
    public interface IHand
    {
        bool HasThisHand(PlayerHand hand);
    }

    public class StraightFlush : IHand
    {
        public bool HasThisHand(PlayerHand hand)
        {
            if (5 > hand.Cards.Count)
            {
                return false;
            }

            Flush flush = new Flush();
            Straight straight = new Straight();

            return flush.HasThisHand(hand) && straight.HasThisHand(hand);
        }
    }

    public class Flush : IHand
    {
        public bool HasThisHand(PlayerHand hand)
        {
            if(5 > hand.Cards.Count)
            {
                return false;
            }

            var x = from c in hand.Cards where c.Suit != hand.Cards[0].Suit select c;

            if (x.Count() > 0)
                return false;

            return true;
        }
    }

    public class Straight : IHand
    {
        public bool HasThisHand(PlayerHand hand)
        {
            if (5 > hand.Cards.Count)
            {
                return false;
            }

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
        public bool HasThisHand(PlayerHand hand)
        {
            if (3 > hand.Cards.Count)
            {
                return false;
            }

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
        public bool HasThisHand(PlayerHand hand)
        {
            if (4 > hand.Cards.Count)
            {
                return false;
            }

            int pairCount = 0;
            foreach (Faces face in hand.Histogram.Keys)
            {
                if (hand.Histogram[face] == 2)
                    pairCount++;
            }

            return 2 == pairCount;
        }
    }

    public class OnePair : IHand
    {
        public bool HasThisHand(PlayerHand hand)
        {
            if (2 > hand.Cards.Count)
            {
                return false;
            }

            int pairCount = 0;
            foreach (Faces face in hand.Histogram.Keys)
            {
                if (hand.Histogram[face] == 2)
                    pairCount++;
            }

            return 1 == pairCount;
        }
    }

    public class FullHouse : IHand
    {
        public bool HasThisHand(PlayerHand hand)
        {
            if (5 > hand.Cards.Count)
            {
                return false;
            }

            ThreeOfAKind threeOfAKind = new ThreeOfAKind();
            OnePair onePair = new OnePair();

            return threeOfAKind.HasThisHand(hand) && onePair.HasThisHand(hand);
        }
    }
}