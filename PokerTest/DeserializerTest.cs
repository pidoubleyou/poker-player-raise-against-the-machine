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
                Pot = 20
            };

            var json = File.ReadAllText(@"testfiles\bet_sample.json");

            JObject input = JObject.Parse(json);

            var actual = target.Deserialize(input);

            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedGameState.Pot, actual.Pot);
            Assert.AreEqual(expectedGameState.SmallBlind, actual.SmallBlind);
            Assert.AreEqual(expectedGameState.CurrentBuyIn, actual.CurrentBuyIn);
        }
    }
}
