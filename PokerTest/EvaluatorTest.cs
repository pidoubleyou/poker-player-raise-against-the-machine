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
    public class EvaluatorTest
    {
        [TestMethod]
        public void GetScore ()
        {
            var target = new Evaluator();
            var cards = new Card[2];
            cards[0] = new Card { Rank = "As" };
            cards[1] = new Card { Rank = "As" };

            var score = target.GetScore(cards);

            Assert.AreEqual(State.Raise, score);
        }
    }
}
