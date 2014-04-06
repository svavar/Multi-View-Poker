using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerModel.DomainObjects;

namespace RazorPoker.Tests.Models
{
    [TestClass]
    public class ScoreModelTest
    {
        [TestMethod]
        public void StraightFlushTest()
        {
            Hand straightFlush = new Hand(new Card(Suits.Spades, Faces.Ten),
                                 new Card(Suits.Spades, Faces.Jack),
                                 new Card(Suits.Spades, Faces.Queen),
                                 new Card(Suits.Spades, Faces.King),
                                 new Card(Suits.Spades, Faces.Ace));

            Hand straightNotFlush = new Hand(new Card(Suits.Spades, Faces.Ten),
                                 new Card(Suits.Spades, Faces.Jack),
                                 new Card(Suits.Diamonds, Faces.Queen),
                                 new Card(Suits.Spades, Faces.King),
                                 new Card(Suits.Spades, Faces.Ace));

            Hand flushNotStraight = new Hand(new Card(Suits.Spades, Faces.Ten),
                     new Card(Suits.Spades, Faces.Jack),
                     new Card(Suits.Spades, Faces.Four),
                     new Card(Suits.Spades, Faces.King),
                     new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new StraightFlush();

            Assert.IsTrue(handModel.HasThisHand(straightFlush));
            Assert.IsFalse(handModel.HasThisHand(straightNotFlush));
            Assert.IsFalse(handModel.HasThisHand(flushNotStraight));
        }

        [TestMethod]
        public void ThreeOfAKindTest()
        {
            Hand threeOfAKind = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.Ten),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Spades, Faces.Ace));

            Hand twoPairs = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.King),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Spades, Faces.Ace)); 
            
            IHand handModel = new ThreeOfAKind();


            Assert.IsTrue(handModel.HasThisHand(threeOfAKind));
            Assert.IsFalse(handModel.HasThisHand(twoPairs));
        }

        [TestMethod]
        public void TwoPairTest()
        {
            Hand threeOfAKind = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.Ten),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Spades, Faces.Ace));

            Hand twoPairs = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.King),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Spades, Faces.Ace));

            Hand onePair = new Hand(new Card(Suits.Spades, Faces.Ten),
                             new Card(Suits.Clubs, Faces.Ten),
                             new Card(Suits.Hearts, Faces.Eight),
                             new Card(Suits.Spades, Faces.King),
                             new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new TwoPair();

            Assert.IsFalse(handModel.HasThisHand(onePair));
            Assert.IsFalse(handModel.HasThisHand(threeOfAKind));
            Assert.IsTrue(handModel.HasThisHand(twoPairs));
        }

        [TestMethod]
        public void OnePairTest()
        {
            Hand threeOfAKind = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.Ten),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Spades, Faces.Ace));

            Hand twoPairs = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.King),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Spades, Faces.Ace));

            Hand onePair = new Hand(new Card(Suits.Spades, Faces.Ten),
                             new Card(Suits.Clubs, Faces.Ten),
                             new Card(Suits.Hearts, Faces.Eight),
                             new Card(Suits.Spades, Faces.King),
                             new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new OnePair();

            Assert.IsTrue(handModel.HasThisHand(onePair));
            Assert.IsFalse(handModel.HasThisHand(threeOfAKind));
            Assert.IsFalse(handModel.HasThisHand(twoPairs));
        }


        [TestMethod]
        public void FullHouseTest()
        {
            Hand fullHouse = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.Ten),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Hearts, Faces.King));

            Hand threeOfAKind = new Hand(new Card(Suits.Spades, Faces.Ten),
                             new Card(Suits.Clubs, Faces.Ten),
                             new Card(Suits.Hearts, Faces.Ten),
                             new Card(Suits.Spades, Faces.King),
                             new Card(Suits.Spades, Faces.Ace));

            Hand twoPairs = new Hand(new Card(Suits.Spades, Faces.Ten),
                                         new Card(Suits.Clubs, Faces.Ten),
                                         new Card(Suits.Hearts, Faces.King),
                                         new Card(Suits.Spades, Faces.King),
                                         new Card(Suits.Spades, Faces.Ace));

            Hand onePair = new Hand(new Card(Suits.Spades, Faces.Ten),
                             new Card(Suits.Clubs, Faces.Ten),
                             new Card(Suits.Hearts, Faces.Eight),
                             new Card(Suits.Spades, Faces.King),
                             new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new FullHouse();

            Assert.IsTrue(handModel.HasThisHand(fullHouse));
            Assert.IsFalse(handModel.HasThisHand(onePair));
            Assert.IsFalse(handModel.HasThisHand(threeOfAKind));
            Assert.IsFalse(handModel.HasThisHand(twoPairs));
        }
    }
}
