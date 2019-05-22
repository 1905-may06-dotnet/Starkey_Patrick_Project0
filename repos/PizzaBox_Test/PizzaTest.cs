using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaBox_Domain;
namespace PizzaBox_Test
{
    [TestClass]
    public class PizzaTest
    {
        [TestMethod]
        public void Testcost()
        {
            PizzaOrder testing = new PizzaOrder();
            testing.Cost("medium", 2);
            decimal expectedcost = (7 + 2 * .75m);
            decimal Actualcost= testing.Cost("medium", 2);
            Assert.AreEqual(expectedcost, Actualcost);
        }


    }
}
