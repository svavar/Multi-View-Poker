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
        public List<Card> InitialDeal();
        public List<Card> NextDeal();
        public void PlayerAction();
        public void DealerAction();
    }
}
