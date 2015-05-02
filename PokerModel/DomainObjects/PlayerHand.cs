using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerModel.DomainObjects
{
    public class PlayerHand
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

        public PlayerHand()
        {
            histogram = new Dictionary<Faces, int>();
            sortedHand = new List<Card>();
        }

        public List<Card> Cards { get { return sortedHand; } }
        public Dictionary<Faces, int> Histogram { get { return histogram; } }

        public Card HighCard
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
}