using PokerWebService.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PokerWebService
{
    public class TexasHoldemService : IPokerService
    {
        public List<DataContracts.ITable> ListTables()
        {
            throw new NotImplementedException();
        }

        public DataContracts.ITable JoinTable(int tableId)
        {
            throw new NotImplementedException();
        }

        public DataContracts.ITable CreateTable(string tableName)
        {
            return new TexasHoldemTable() { Name = tableName };
        }
    }
}