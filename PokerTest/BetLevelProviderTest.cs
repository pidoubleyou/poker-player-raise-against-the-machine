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

        [TestMethod]
        public void GetBetLevelTestHighRaiseOtherPlayer()
        {
            var gameState = new GameState
            {
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = Constants.PlayerName, Status = "active", Bet = 0, Stack = 1000 },
                    new PlayerInfo { Name = "X", Status = "active", Bet = 200, Stack = 200 },
                    new PlayerInfo { Name = "Y", Status = "active", Bet = 0, Stack = 300 },
                }
            };

            var target = new BetLevelProvider();
            var actual = target.GetBetLevel(gameState);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is HighRaiseBetLevel);
        }
    }
}
