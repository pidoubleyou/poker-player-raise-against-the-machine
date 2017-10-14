using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class BetCalculator
    {
        public int calculate(GameState gameState, State state)
        {
            switch(state)
            {
                case State.Fold:
                    return 0;
                case State.Call:
                    return calculateCallBet(gameState);
                default:
                    return 1000;
            }
        }

        private int calculateCallBet(GameState gameState)
        {
            return gameState.CurrentBuyIn - gameState.Self.Bet;
        }
    }
}
