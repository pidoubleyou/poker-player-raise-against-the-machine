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
    public class PlayerInfoTest
    {
        [TestMethod]
        public void HasRaisedHighTestFalseIfNoRaise()
        {
            var player = new PlayerInfo { Bet = 0 };

            var actual = player.HasRaisedHigh();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void HasRaisedHighTestFalseIfLessFiftyPercentOfStack()
        {
            var player = new PlayerInfo { Bet = 399, Stack = 400 };

            var actual = player.HasRaisedHigh();

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void HasRaisedHighTestTrueIfFiftyPercentOfInitialStack()
        {
            var player = new PlayerInfo { Bet = 400, Stack = 400 };

            var actual = player.HasRaisedHigh();

            Assert.IsTrue(actual);
        }
    }
}
