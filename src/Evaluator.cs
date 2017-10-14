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
            if (cards[0].Rank == cards[1].Rank)
                return State.Raise;

            return State.Call;
        }
    }
}
