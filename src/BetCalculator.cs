using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class BetCalculator
    {
        public int calculate(GameState gameState, int evaluation)
        {
            if (evaluation == 0)
                return 0;

            if (evaluation <= 6)
                return calculateCallBet(gameState);

            if (evaluation <= 8)
                return calculateRaise(gameState);

            return gameState.Self.Stack;
        }

        private int calculateRaise(GameState gameState) { 
        
            var raise = gameState.MinimumRaise;
            if(raise > gameState.Self.Stack)
            {
                raise = gameState.Self.Stack;
            }

            return raise;
        }

        private int calculateCallBet(GameState gameState)
        {
            return gameState.CurrentBuyIn - gameState.Self.Bet;
        }
    }
}
