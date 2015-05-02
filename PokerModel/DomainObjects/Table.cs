using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerModel.DomainObjects
{
    public class Table
    {
        public List<Player> Players { get; private set; }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}