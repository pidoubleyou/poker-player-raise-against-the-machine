using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTest
{
    [TestClass]
    public class DeserializerTest
    {
        private Deserializer target;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new Deserializer();
        }

        [TestMethod]
        [DeploymentItem("bet_sample.json", "testfiles")]
        public void Test()
        {
            var expectedGameState = new GameState
            {
                SmallBlind = 100,
                CurrentBuyIn = 5,
                Pot = 20,
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = "Player 1", Bet= 0, Stack = 1000, Cards = new Card[] { new Card { Rank = "7", Suit = "spades" }, new Card { Rank = "7", Suit = "hearts" } } },
                    new PlayerInfo { Name = "Player 2", Bet = 20, Stack = 1000,Cards = new Card[] { new Card { Rank = "6", Suit = "hearts" }, new Card { Rank = "K", Suit = "spades" } } }
                }
            };

            var json = File.ReadAllText(@"testfiles\bet_sample.json");

            JObject input = JObject.Parse(json);

            var actual = target.Deserialize(input);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedGameState.Pot, actual.Pot);
            Assert.AreEqual(expectedGameState.SmallBlind, actual.SmallBlind);
            Assert.AreEqual(expectedGameState.CurrentBuyIn, actual.CurrentBuyIn);

            Assert.AreEqual(expectedGameState.Players.Count(), actual.Players.Count());
            for(int i = 0; i < expectedGameState.Players.Count(); i++)
            {
                Assert.AreEqual(expectedGameState.Players[i].Bet, actual.Players[i].Bet);
                Assert.AreEqual(expectedGameState.Players[i].Name, actual.Players[i].Name);
                Assert.AreEqual(expectedGameState.Players[i].Stack, actual.Players[i].Stack);

                for(int j = 0; j < expectedGameState.Players[i].Cards.Count(); j++)
                {
                    Assert.AreEqual(expectedGameState.Players[i].Cards[j].Rank, actual.Players[i].Cards[j].Rank);
                    Assert.AreEqual(expectedGameState.Players[i].Cards[j].Suit, actual.Players[i].Cards[j].Suit);
                }
            }
        }
    }
}
