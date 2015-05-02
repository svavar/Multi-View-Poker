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
    [ServiceContract]
    public interface IPokerService
    {
        [OperationContract]
        List<ITable> ListTables();

        [OperationContract]
        ITable JoinTable(int tableId);

        [OperationContract]
        ITable CreateTable(string tableName);
    }
}