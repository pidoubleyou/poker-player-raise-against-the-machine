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
            if (IsPair(cards))
                return State.AllIn;

            if (IsSameColor(cards))
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
    }
}
