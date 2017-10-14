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
        public void GetScore_PairWithHandCards_Pair()
        {
            var target = new Evaluator();
            var cards = new List<Card>();
            cards.Add(new Card { Rank = "A", Suit = "Clubs" });
            cards.Add(new Card { Rank = "6", Suit = "Clubs" });
            cards.Add(new Card { Rank = "7", Suit = "Clubs" });
            cards.Add(new Card { Rank = "A", Suit = "Clubs" });
            cards.Add(new Card { Rank = "5", Suit = "Spades" });

            var score = target.GetScore(cards);

            Assert.AreEqual(7, score);
        }
        [TestMethod]
        public void GetScore_PairWithCommunityCards_NoScore()
        {
            var target = new Evaluator();
            var cards = new List<Card>();
            cards.Add(new Card { Rank = "A", Suit = "Clubs" });
            cards.Add(new Card { Rank = "6", Suit = "Clubs" });
            cards.Add(new Card { Rank = "7", Suit = "Clubs" });
            cards.Add(new Card { Rank = "7", Suit = "Clubs" });
            cards.Add(new Card { Rank = "5", Suit = "Spades" });

            var score = target.GetScore(cards);

            Assert.AreEqual(0, score);
        }
        [TestMethod]
        public void GetScore_SameRank_Ass()
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

            Assert.AreEqual(8, score);
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

            Assert.AreEqual(6, score);
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

            var score = target.ContainsMulitpleCards(cards, 2);

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

            var score = target.ContainsMulitpleCards(cards, 2);

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

            var score = target.ContainsMulitpleCards(cards, 3);

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

            var score = target.ContainsMulitpleCards(cards, 3);

            Assert.IsFalse(score);
        }
        [TestMethod]
        public void ContainsTwoPairs_TwoPairs_True()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" }
            };

            var score = target.ContainsTwoPair(cards);

            Assert.IsTrue(score);
        }
        [TestMethod]
        public void ContainsTwoPair_NoTwoPair_False()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "9", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.ContainsTwoPair(cards);

            Assert.IsFalse(score);
        }
        [TestMethod]
        public void ContainsFlush_Flush_True()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" }
            };

            var score = target.ContainsFlush(cards);

            Assert.IsTrue(score);
        }
        [TestMethod]
        public void ContainsTwoPair_NoFlush_False()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "XY" },
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "9", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.ContainsFlush(cards);

            Assert.IsFalse(score);
        }
        [TestMethod]
        public void ContainsStreet_Street_True()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "10", Suit = "Pik" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "J", Suit = "Pik" },
                new Card { Rank = "9", Suit = "Pik" }
            };

            var score = target.ContainsStreet(cards);

            Assert.IsTrue(score);
        }
        [TestMethod]
        public void ContainsStreet_NoStreet_False()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "XY" },
                new Card { Rank = "8", Suit = "Pik" },
                new Card { Rank = "9", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.ContainsStreet(cards);

            Assert.IsFalse(score);
        }
        [TestMethod]
        public void ContainsFullHouse_FullHouse_True()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "10", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "10", Suit = "Pik" }
            };

            var score = target.ContainsFullHouse(cards);

            Assert.IsTrue(score);
        }
        [TestMethod]
        public void ContainsStreet_NoDrilling_False()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "XY" },
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.ContainsFullHouse(cards);

            Assert.IsFalse(score);
        }
        [TestMethod]
        public void ContainsFullHouse_NoPair_False()
        {
            var target = new Evaluator();
            var cards = new List<Card>
            {
                new Card { Rank = "A", Suit = "Pik" },
                new Card { Rank = "7", Suit = "XY" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "7", Suit = "Pik" },
                new Card { Rank = "K", Suit = "Pik" }
            };

            var score = target.ContainsFullHouse(cards);

            Assert.IsFalse(score);
        }
    }
}
