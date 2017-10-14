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
                case State.AllIn:
                    return gameState.Self.Stack;
                case State.Raise:
                    return calculateRaise(gameState);
                default:
                    return 0;
            }
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
