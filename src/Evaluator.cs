﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class Evaluator
    {
        public int GetScore (List<Card> cards)
        {
            if (IsHand(cards))
            {
                return GetScoreHandCards(cards);
            }
            return GetScoreAllCards(cards);
        }

        private static int GetScoreHandCards(List<Card> cards)
        {
            // Pärchen behandeln
            if (IsPair(cards) && GetSumCards(cards) > 20)
                return 10;
            if (IsPair(cards)) {
                return 8;
            }

            // Höhe der Karte
            if (IsSameColor(cards) && GetSumCards(cards) > 25)
                return 8;
            if (IsSameColor(cards) && GetSumCards(cards) > 12)
                return 6;
            if (GetSumCards(cards) > 25)
                return 7;
            if (GetSumCards(cards) > 21)
                return 5;

            return 0;
        }

        private static bool IsPair(List<Card> cards)
        {
            return cards[0].Rank == cards[1].Rank;
        }

        public static bool IsSameColor(List<Card> cards)
        {
            return cards[0].Suit == cards[1].Suit;
        }

        public static int GetSumCards(List<Card> cards)
        {
            return cards[0].Value + cards[1].Value;
        }

        private int GetScoreAllCards(List<Card> cards)
        {
            var communityCards = cards.Skip(2).ToList();
            var scoreWithHandCards = GetScoreCards(cards);
            var scoreCommunityCards = GetScoreCards(communityCards);

            if (scoreCommunityCards == scoreWithHandCards)
                return 0;

            return scoreWithHandCards;
        }
        private int GetScoreCards(List<Card> cards)
        {
            if (ContainsFourOfAKind(cards))
            {
                return 10;
            }
            if (ContainsFlush(cards))
            {
                return 10;
            }
            if (ContainsFullHouse(cards))
            {
                return 10;
            }
            if (ContainsStreet(cards))
            {
                return 9;
            }
            if (ContainsTriple(cards))
            {
                return 9;
            }
            if (ContainsTwoPair(cards))
            {
                return 8; 
            }
            if (ContainsOnePair(cards))
            {
                if(ContainsMulitpleCards(communityCards, 2))
                {
                    return 0;
                }

                if(GetSumCards(cards) > 20)
                {
                    return 7;
                }
                if(IsFlop(cards))
                {
                   return 5;
                }
                return 2;
            }
            return 0;
        }

        private bool ContainsOnePair(List<Card> cards)
        {
            return ContainsMulitpleCards(cards, 2);
        }

        private bool ContainsTriple(List<Card> cards)
        {
            return ContainsMulitpleCards(cards, 3);
        }

        private bool ContainsFourOfAKind(List<Card> cards)
        {
            return ContainsMulitpleCards(cards, 4);
        }

        public bool ContainsStreet(List<Card> cards)
        {
            return cards.Any(c => IsStreet(cards, c.Value));
        }

        private bool IsStreet(List<Card> cards, int startValue)
        {
            if (!cards.Any(c => c.Value == startValue + 1))
                return false;
            if (!cards.Any(c => c.Value == startValue + 2))
                return false;
            if (!cards.Any(c => c.Value == startValue + 3))
                return false;
            if (!cards.Any(c => c.Value == startValue + 4))
                return false;

            return true;
        }

        public bool ContainsFlush(List<Card> cards)
        {
            var groupList = cards.GroupBy(c => c.Suit);
            return groupList.Any(g => g.Count() >= 5);
        }

        public bool ContainsMulitpleCards(List<Card> cards, int countKind)
        {
            var groupList = cards.GroupBy(c => c.Value);
            return groupList.Any(g => g.Count() == countKind);
        }
        public bool ContainsFullHouse(List<Card> cards)
        {
            var groupList = cards.GroupBy(c => c.Value);
            var drilling = groupList.Where(g => g.Count() == 3).FirstOrDefault();
            if (drilling == null)
                return false;

            var drillingValue = drilling.First().Value;
            var pair = groupList.Where(g => g.Count() >= 2 && g.First().Value != drillingValue).FirstOrDefault();

            return pair != null;
        }
        public bool ContainsTwoPair(List<Card> cards)
        {
            var groupList = cards.GroupBy(c => c.Value);
            return groupList.Count(g => g.Count() == 2) == 2;
        }

        private static bool IsHand(List<Card> cards)
        {
            return cards.Count == 2;
        }
        private static bool IsFlop(List<Card> cards)
        {
            return cards.Count == 5;
        }
        private static bool IsRiver(List<Card> cards)
        {
            return cards.Count == 6;
        }
        private static bool IsTurn(List<Card> cards)
        {
            return cards.Count == 7;
        }
    }
}
