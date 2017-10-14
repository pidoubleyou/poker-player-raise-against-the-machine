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
            return State.Call;
        }
    }
}
