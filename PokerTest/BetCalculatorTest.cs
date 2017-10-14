﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var actual = target.calculate(new GameState(), State.Fold);

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
                    new PlayerInfo() { Name = Constants.PlayerName, Bet = 0 }
                }
            };

            var actual = target.calculate(gameState, State.Call);

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

            var actual = target.calculate(gameState, State.Call);

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
                    new PlayerInfo() { Name = Constants.PlayerName, Bet = 10 }
                }
            };

            var actual = target.calculate(gameState, State.Call);

            Assert.AreEqual(20, actual);
        }

    }
}
