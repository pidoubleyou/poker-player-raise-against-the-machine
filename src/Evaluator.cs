using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class Evaluator
    {
        public State GetScore (Card[] cards)
        {
            // Pärchen behandeln
            if (IsPair(cards) && GetSumCards(cards) > 20)
                return State.AllIn;
            if (IsPair(cards))
                return State.Raise;

            // Höhe der Karte
            if (IsSameColor(cards) && GetSumCards(cards) > 25)
                return State.AllIn;
            if (IsSameColor(cards) && GetSumCards(cards) > 12)
                return State.Raise;
            if (GetSumCards(cards) > 25)
                return State.Raise;
            if (GetSumCards(cards) > 21)
                return State.Call;

            return State.Fold;
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
            return 10;
        }
    }
}
