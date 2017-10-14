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
            var cards = new List<Card>();
            cards.Add(new Card { Rank = "A", Suit = "Clubs" });
            cards.Add(new Card { Rank = "A", Suit = "Spades" });

            var score = target.GetScore(cards);

            Assert.AreEqual(10, score);
        }

        [TestMethod]
        public void GetScore_SameRank_9()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "9", Suit = "Clubs" },
                new Card { Rank = "9", Suit = "Spades" }
            };

            var score = target.GetScore(cards);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void GetScore_SameRankKleineKarte()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "7" },
                new Card { Rank = "7" }
            };

            var score = target.GetScore(cards);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void GetScore_SameColor_Fold()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "6", Suit = "Pik" },
                new Card { Rank = "2", Suit = "Pik" }
            };
        

            var score = target.GetScore(cards);

            Assert.AreEqual(0, score);
        }
        [TestMethod]
        public void GetScore_SameColor_AllIn()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.GetScore(cards);

            Assert.AreEqual(10, score);
        }
        [TestMethod]
        public void GetScore_SameColor_Raise()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "2", Suit = "Pik" }
            };

            var score = target.GetScore(cards);

            Assert.AreEqual(8, score);
        }

        [TestMethod]
        public void ContainsPair_Pair_True()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "A", Suit = "Pik" }
            };

            var score = target.ContainsPair(cards);

            Assert.IsTrue(score);
        }
        [TestMethod]
        public void ContainsPair_NoPair_False()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.ContainsPair(cards);

            Assert.IsFalse(score);
        }
        [TestMethod]
        public void ContainsTriple_Triple_True()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "A", Suit = "Pik" }
            };

            var score = target.ContainsTriple(cards);

            Assert.IsTrue(score);
        }
        [TestMethod]
        public void ContainsTriple_NoTriple_False()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "9", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.ContainsTriple(cards);

            Assert.IsFalse(score);
        }
    }
}
