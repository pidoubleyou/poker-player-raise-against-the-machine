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
    public class BetLevelProviderTest
    {
        [TestMethod]
        public void GetBetLevelTestNoHeadsUp()
        {
            var gameState = new GameState
            {
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Status = "active" },
                    new PlayerInfo { Status = "active" },
                    new PlayerInfo { Status = "active" }
                }
            };

            var target = new BetLevelProvider();
            var actual = target.GetBetLevel(gameState);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is DefaultBetLevel);
        }

        [TestMethod]
        public void GetBetLevelTestHeadsUp()
        {
            var gameState = new GameState
            {
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Status = "active" },
                    new PlayerInfo { Status = "active" },
                    new PlayerInfo { Status = "out" }
                }
            };

            var target = new BetLevelProvider();
            var actual = target.GetBetLevel(gameState);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is HeadsUpBetLevel);
        }
    }
}
