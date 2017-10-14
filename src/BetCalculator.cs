using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class BetCalculator
    {
        public int calculate(State state)
        {
            switch(state)
            {
                case State.Fold:
                    return 0;
                default:
                    return 1000;
            }
        }
    }
}
