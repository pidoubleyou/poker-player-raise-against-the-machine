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
            var actual = target.calculate(new GameState(), 0);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void calculateTestCallNothingBet()
        {
            var gameState = new GameState()
            {
                CurrentBuyIn = 10,
                Players = new PlayerInfo[]
                {
                    new PlayerInfo() { Name = Constants.PlayerName, Bet = 0, Stack = 1000 }
                }
            };

            var actual = target.calculate(gameState, 6);

            Assert.AreEqual(10, actual);
        }

        [TestMethod]
        public void calculateTestCallNothingToBet()
        {
            var gameState = new GameState()
            {
                CurrentBuyIn = 10,
                Players = new PlayerInfo[]
                {
                    new PlayerInfo() { Name = Constants.PlayerName, Bet = 10 }
                }
            };

            var actual = target.calculate(gameState, 6);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void calculateTestCallAlreadyBet()
        {
            var gameState = new GameState()
            {
                CurrentBuyIn = 30,
                Players = new PlayerInfo[]
                {
                    new PlayerInfo() { Name = Constants.PlayerName, Bet = 10, Stack = 1000 }
                }
            };

            var actual = target.calculate(gameState, 6);

            Assert.AreEqual(20, actual);
        }

        [TestMethod]
        public void calculateTestDontCallIfBetIsTooHigh()
        {
            var gameState = new GameState()
            {
                CurrentBuyIn = 500,
                Players = new PlayerInfo[]
                {
                    new PlayerInfo() { Name = Constants.PlayerName, Bet = 0, Stack = 1000 },
                }
            };

            var actual = target.calculate(gameState, 6);

            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void calculateTestAllIn()
        {
            var gameState = new GameState()
            {
                CurrentBuyIn = 30,
                Players = new PlayerInfo[]
                {
                    new PlayerInfo() { Name = Constants.PlayerName, Stack = 877, Bet = 10 },
                }
            };

            var actual = target.calculate(gameState, 10);

            Assert.AreEqual(877, actual);
        }

        [TestMethod]
        public void calculateTestRaiseMinimum()
        {
            var gameState = new GameState()
            {
                CurrentBuyIn = 30,
                MinimumRaise = 155,
                Players = new PlayerInfo[] 
                {
                    new PlayerInfo() { Name = Constants.PlayerName, Stack = 877, Bet = 10 }
                }
            };

            var actual = target.calculate(gameState, 8);

            Assert.AreEqual(155, actual);

        }

        [TestMethod]
        public void calculateTestRaiseMinimumLargerStack()
        {
            var gameState = new GameState()
            {
                CurrentBuyIn = 30,
                MinimumRaise = 655,
                Players = new PlayerInfo[]
                {
                    new PlayerInfo() { Name = Constants.PlayerName, Stack = 223, Bet = 10 }
                }
            };

            var actual = target.calculate(gameState, 8);

            Assert.AreEqual(223, actual);

        }
    }
}
