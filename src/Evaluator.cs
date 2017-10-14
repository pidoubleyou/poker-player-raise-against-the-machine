﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class Evaluator
    {
        public int GetScore (Card[] cards)
        {
            if (cards.Count() == 2)
            {
                return GetScoreHandCards(cards);
            }
            return 0;
        }

        private static int GetScoreHandCards(Card[] cards)
        {
            // Pärchen behandeln
            if (IsPair(cards) && GetSumCards(cards) > 20)
                return 10;
            if (IsPair(cards))
                return 8;

            // Höhe der Karte
            if (IsSameColor(cards) && GetSumCards(cards) > 25)
                return 10;
            if (IsSameColor(cards) && GetSumCards(cards) > 12)
                return 8;
            if (GetSumCards(cards) > 25)
                return 8;
            if (GetSumCards(cards) > 21)
                return 6;

            return 0;
        }

        private static bool IsPair(Card[] cards)
        {
            return cards[0].Rank == cards[1].Rank;
        }

        public static bool IsSameColor(Card[] cards)
        {
            return cards[0].Suit == cards[1].Suit;
        }

        public static int GetSumCards(Card[] cards)
        {
            return cards[0].Value + cards[1].Value;
        }
    }
}
