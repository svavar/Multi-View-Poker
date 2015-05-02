using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerModel.DomainObjects;

namespace PokerModel.Controllers
{
    public interface IPokerController
    {
        List<Card> InitialDeal();
        List<Card> NextDeal();
        void PlayerAction();
        void DealerAction();
        void Showdown();
    }
}
