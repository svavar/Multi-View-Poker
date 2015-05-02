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
            PlayerHand straightFlush = new PlayerHand();
            straightFlush.AddCard(new Card(Suits.Spades, Faces.Ten));
            straightFlush.AddCard(new Card(Suits.Spades, Faces.Jack));
            straightFlush.AddCard(new Card(Suits.Spades, Faces.Queen));
            straightFlush.AddCard(new Card(Suits.Spades, Faces.King));
            straightFlush.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand straightNotFlush = new PlayerHand();
            straightNotFlush.AddCard(new Card(Suits.Spades, Faces.Ten));
            straightNotFlush.AddCard(new Card(Suits.Spades, Faces.Jack));
            straightNotFlush.AddCard(new Card(Suits.Diamonds, Faces.Queen));
            straightNotFlush.AddCard(new Card(Suits.Spades, Faces.King));
            straightNotFlush.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand flushNotStraight = new PlayerHand();
            flushNotStraight.AddCard(new Card(Suits.Spades, Faces.Ten));
            flushNotStraight.AddCard(new Card(Suits.Spades, Faces.Jack));
            flushNotStraight.AddCard(new Card(Suits.Spades, Faces.Four));
            flushNotStraight.AddCard(new Card(Suits.Spades, Faces.King));
            flushNotStraight.AddCard(new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new StraightFlush();

            Assert.IsTrue(handModel.HasThisHand(straightFlush));
            Assert.IsFalse(handModel.HasThisHand(straightNotFlush));
            Assert.IsFalse(handModel.HasThisHand(flushNotStraight));
        }

        [TestMethod]
        public void ThreeOfAKindTest()
        {
            PlayerHand threeOfAKind = new PlayerHand();
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Clubs, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Hearts, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.King));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand twoPairs = new PlayerHand();
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Clubs, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Hearts, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ace)); 
            
            IHand handModel = new ThreeOfAKind();


            Assert.IsTrue(handModel.HasThisHand(threeOfAKind));
            Assert.IsFalse(handModel.HasThisHand(twoPairs));
        }

        [TestMethod]
        public void TwoPairTest()
        {
            PlayerHand threeOfAKind = new PlayerHand();
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Clubs, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Hearts, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.King));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand twoPairs = new PlayerHand();
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Clubs, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Hearts, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand onePair = new PlayerHand();
            onePair.AddCard(new Card(Suits.Spades, Faces.Ten));
            onePair.AddCard(new Card(Suits.Clubs, Faces.Ten));
            onePair.AddCard(new Card(Suits.Hearts, Faces.Eight));
            onePair.AddCard(new Card(Suits.Spades, Faces.King));
            onePair.AddCard(new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new TwoPair();

            Assert.IsFalse(handModel.HasThisHand(onePair));
            Assert.IsFalse(handModel.HasThisHand(threeOfAKind));
            Assert.IsTrue(handModel.HasThisHand(twoPairs));
        }

        [TestMethod]
        public void OnePairTest()
        {
            PlayerHand threeOfAKind = new PlayerHand();
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Clubs, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Hearts, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.King));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand twoPairs = new PlayerHand();
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Clubs, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Hearts, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand onePair = new PlayerHand();
            onePair.AddCard(new Card(Suits.Spades, Faces.Ten));
            onePair.AddCard(new Card(Suits.Clubs, Faces.Ten));
            onePair.AddCard(new Card(Suits.Hearts, Faces.Eight));
            onePair.AddCard(new Card(Suits.Spades, Faces.King));
            onePair.AddCard(new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new OnePair();

            Assert.IsTrue(handModel.HasThisHand(onePair));
            Assert.IsFalse(handModel.HasThisHand(threeOfAKind));
            Assert.IsFalse(handModel.HasThisHand(twoPairs));
        }


        [TestMethod]
        public void FullHouseTest()
        {
            PlayerHand fullHouse = new PlayerHand();
            fullHouse.AddCard(new Card(Suits.Spades, Faces.Ten));
                    fullHouse.AddCard(new Card(Suits.Clubs, Faces.Ten));
                    fullHouse.AddCard(new Card(Suits.Hearts, Faces.Ten));
                    fullHouse.AddCard(new Card(Suits.Spades, Faces.King));
                    fullHouse.AddCard(new Card(Suits.Hearts, Faces.King));

            PlayerHand threeOfAKind = new PlayerHand();
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Clubs, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Hearts, Faces.Ten));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.King));
            threeOfAKind.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand twoPairs = new PlayerHand();
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Clubs, Faces.Ten));
            twoPairs.AddCard(new Card(Suits.Hearts, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.King));
            twoPairs.AddCard(new Card(Suits.Spades, Faces.Ace));

            PlayerHand onePair = new PlayerHand();
            onePair.AddCard(new Card(Suits.Spades, Faces.Ten));
            onePair.AddCard(new Card(Suits.Clubs, Faces.Ten));
            onePair.AddCard(new Card(Suits.Hearts, Faces.Eight));
            onePair.AddCard(new Card(Suits.Spades, Faces.King));
            onePair.AddCard(new Card(Suits.Spades, Faces.Ace));

            IHand handModel = new FullHouse();

            Assert.IsTrue(handModel.HasThisHand(fullHouse));
            Assert.IsFalse(handModel.HasThisHand(onePair));
            Assert.IsFalse(handModel.HasThisHand(threeOfAKind));
            Assert.IsFalse(handModel.HasThisHand(twoPairs));
        }
    }
}
