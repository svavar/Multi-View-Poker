using PokerModel.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PokerWebService.DataContracts
{
    [ServiceContract]
    public interface ITable
    {
        [DataMember]
        int ID { get; set; }

        [DataMember]
        string Name { get; set; }        

        [DataMember]
        List<Player> Players { get; set; }

        [DataMember]
        Player Dealer { get; set; }

        [DataMember]
        Player BigBlind { get; set; }

        [DataMember]
        Player SmallBlind { get; set; }
    }
}
