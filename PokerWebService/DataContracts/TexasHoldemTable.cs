using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using PokerModel.DomainObjects;

namespace PokerWebService.DataContracts
{
    [DataContract]
    public class TexasHoldemTable : ITable
    {
        public List<Player> Players
        {
            get;
            set;
        }

        public Player Dealer
        {
            get;
            set;
        }

        public Player BigBlind
        {
            get;
            set;
        }

        public Player SmallBlind
        {
            get;
            set;
        }

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}