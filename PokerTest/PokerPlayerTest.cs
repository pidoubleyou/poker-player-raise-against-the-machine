using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using Newtonsoft.Json.Linq;

namespace PokerTest
{
    [TestClass]
    public class PokerPlayerTest
    {
        [TestMethod]
        [DeploymentItem("game_state_sample_round16.json", "testfiles")]
        public void Round16_Then2066Expected()
        {
            var json = File.ReadAllText(@"testfiles\game_state_sample_round16.json");

            JObject input = JObject.Parse(json);

            int bet = PokerPlayer.BetRequest(input);

            Assert.AreEqual(2066, bet);
        }
    }
}
