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
        public void GetScore_SameRank_Ass ()
        {
            var target = new Evaluator();
            var cards = new Card[2];
            cards[0] = new Card { Rank = "A", Suit = "Clubs" };
            cards[1] = new Card { Rank = "A", Suit = "Spades" };

            var score = target.GetScore(cards);

            Assert.AreEqual(10, score);
        }

        [TestMethod]
        public void GetScore_SameRank_9()
        {
            var target = new Evaluator();
            var cards = new Card[2];
            cards[0] = new Card { Rank = "9", Suit = "Clubs" };
            cards[1] = new Card { Rank = "9", Suit = "Spades" };

            var score = target.GetScore(cards);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void GetScore_SameRankKleineKarte()
        {
            var target = new Evaluator();
            var cards = new Card[2];
            cards[0] = new Card { Rank = "7" };
            cards[1] = new Card { Rank = "7" };

            var score = target.GetScore(cards);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void GetScore_SameColor_Fold()
        {
            var target = new Evaluator();
            var cards = new Card[2];
            cards[0] = new Card { Rank = "6", Suit = "Pik" };
            cards[1] = new Card { Rank = "2", Suit = "Pik" };

            var score = target.GetScore(cards);

            Assert.AreEqual(0, score);
        }
        [TestMethod]
        public void GetScore_SameColor_AllIn()
        {
            var target = new Evaluator();
            var cards = new Card[2];
            cards[0] = new Card { Rank = "A", Suit = "Pik" };
            cards[1] = new Card { Rank = "K", Suit = "Pik" };

            var score = target.GetScore(cards);

            Assert.AreEqual(10, score);
        }
        [TestMethod]
        public void GetScore_SameColor_Raise()
        {
            var target = new Evaluator();
            var cards = new Card[2];
            cards[0] = new Card { Rank = "A", Suit = "Pik" };
            cards[1] = new Card { Rank = "2", Suit = "Pik" };

            var score = target.GetScore(cards);

            Assert.AreEqual(8, score);
        }
    }
}
