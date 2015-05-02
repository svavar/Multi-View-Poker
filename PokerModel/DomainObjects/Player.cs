using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerModel.DomainObjects
{
    public class Player
    {
        public string Name { get; private set; }        
        public PlayerHand Hand { get; private set; }
    }
}