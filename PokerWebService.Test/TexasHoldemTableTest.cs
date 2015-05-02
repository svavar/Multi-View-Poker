using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerWebService.Test
{
    [TestClass]
    public class TexasHoldemTableTest
    {
        [TestMethod]
        public void CreateTable()
        {
            TexasHoldemService service = new TexasHoldemService();

            var newTable = service.CreateTable("Test Table");

            Assert.AreEqual("Test Table", newTable.Name);
        }
    }
}
