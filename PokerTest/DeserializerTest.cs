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
        [DeploymentItem("bet_sample_no_community_cards.json", "testfiles")]
        public void DeserializeTestNoCommunityCards()
        {
            var expectedGameState = new GameState
            {
                SmallBlind = 100,
                CurrentBuyIn = 5,
                Pot = 20,
                MinimumRaise = 44,
                CommunityCards = new Card[0],
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = "Player 1", Bet= 0, Stack = 1000, Status = "active", Cards = new Card[] { new Card { Rank = "7", Suit = "spades" }, new Card { Rank = "7", Suit = "hearts" } } },
                    new PlayerInfo { Name = "Player 2", Bet = 20, Stack = 1000, Status = "active", Cards = new Card[] { new Card { Rank = "6", Suit = "hearts" }, new Card { Rank = "K", Suit = "spades" } } },
                    new PlayerInfo { Name = "Player 3", Bet = 0, Stack = 0, Status = "out", Cards = new Card[0] },
                    new PlayerInfo { Name = "Player 4", Bet = 0, Stack = 1000, Status = "folded", Cards = new Card[0] }
                }
            };

            var json = File.ReadAllText(@"testfiles\bet_sample_no_community_cards.json");

            JObject input = JObject.Parse(json);

            var actual = target.Deserialize(input);

            AssertGameState(expectedGameState, actual);
        }

        [TestMethod]
        [DeploymentItem("bet_sample_with_community_cards.json", "testfiles")]
        public void DeserializeTestWithCommunityCards()
        {
            var expectedGameState = new GameState
            {
                SmallBlind = 100,
                CurrentBuyIn = 5,
                Pot = 20,
                MinimumRaise = 44,
                CommunityCards = new Card[] {
                    new Card { Rank = "K", Suit = "hearts" },
                    new Card { Rank = "4", Suit = "spades" },
                    new Card { Rank = "8", Suit = "hearts" }
                },
                Players = new PlayerInfo[]
                {
                    new PlayerInfo { Name = "Player 1", Bet= 0, Stack = 1000, Status = "active", Cards = new Card[] { new Card { Rank = "7", Suit = "spades" }, new Card { Rank = "7", Suit = "hearts" } } },
                    new PlayerInfo { Name = "Player 2", Bet = 20, Stack = 1000, Status = "active", Cards = new Card[] { new Card { Rank = "6", Suit = "hearts" }, new Card { Rank = "K", Suit = "spades" } } }
                }
            };

            var json = File.ReadAllText(@"testfiles\bet_sample_with_community_cards.json");

            JObject input = JObject.Parse(json);

            var actual = target.Deserialize(input);

            AssertGameState(expectedGameState, actual);
        }

        private void AssertGameState(GameState expected, GameState actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Pot, actual.Pot);
            Assert.AreEqual(expected.SmallBlind, actual.SmallBlind);
            Assert.AreEqual(expected.CurrentBuyIn, actual.CurrentBuyIn);
            Assert.AreEqual(expected.CommunityCards.Count(), actual.CommunityCards.Count());

            Assert.AreEqual(expected.Players.Count(), actual.Players.Count());
            for (int i = 0; i < expected.Players.Count(); i++)
            {
                Assert.AreEqual(expected.Players[i].Bet, actual.Players[i].Bet);
                Assert.AreEqual(expected.Players[i].Name, actual.Players[i].Name);
                Assert.AreEqual(expected.Players[i].Stack, actual.Players[i].Stack);
                Assert.AreEqual(expected.Players[i].Status, actual.Players[i].Status);

                for (int j = 0; j < expected.Players[i].Cards.Count(); j++)
                {
                    Assert.AreEqual(expected.Players[i].Cards[j].Rank, actual.Players[i].Cards[j].Rank);
                    Assert.AreEqual(expected.Players[i].Cards[j].Suit, actual.Players[i].Cards[j].Suit);
                }
            }

        }
    }
}
