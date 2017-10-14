using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    [TestClass]
    public class BetCalculatorTest
    {
        private BetCalculator target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new BetCalculator();
        }

        [TestMethod]
        public void calculateTestReturnsNullIfFold()
        {
            var actual = target.calculate(State.Fold);

            Assert.AreEqual(0, actual);
        }
    }
}
