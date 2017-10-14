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
    public class GameStateTest
    {
        [TestMethod]
        public void IsHeadsUpTestThreePlayersReturnsFalse()
        {
            var gameState = new GameState()
            {
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = "X", Status = "active" },
                    new PlayerInfo { Name = "Y", Status = "active" },
                    new PlayerInfo { Name = Constants.PlayerName, Status = "active" }
                }
            };

            var actual = gameState.IsHeadsUp;

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsHeadsUpTestTwoActiveAndOneFoldedReturnsFalse()
        {
            var gameState = new GameState()
            {
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = "X", Status = "active" },
                    new PlayerInfo { Name = "Y", Status = "folded" },
                    new PlayerInfo { Name = Constants.PlayerName, Status = "active" }
                }
            };

            var actual = gameState.IsHeadsUp;

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsHeadsUpTestTwoActiveAndAllOthersOutReturnsTrue()
        {
            var gameState = new GameState()
            {
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = "X", Status = "active" },
                    new PlayerInfo { Name = "Y", Status = "out" },
                    new PlayerInfo { Name = Constants.PlayerName, Status = "active" }
                }
            };

            var actual = gameState.IsHeadsUp;

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void SelfTest()
        {
            var gameState = new GameState()
            {
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = "X" }, 
                    new PlayerInfo { Name = Constants.PlayerName }
                }
            };

            var actual = gameState.Self;

            Assert.IsNotNull(actual);
            Assert.AreEqual(Constants.PlayerName, actual.Name);
        }
    }
}
