﻿namespace Nancy.Simple
{
    public class BetCalculator
    {
        private const double MaximumCallBet = 0.2;
        private const double MaximumCallRaise = 0.5;

        public int calculate(GameState gameState, int evaluation, IBetLevel betLevel)
        {
            if (evaluation <= betLevel.FoldLevel)
                return 0;

            if (evaluation <= betLevel.CallLevel)
                return calculateCallBet(gameState);

            if (evaluation <= betLevel.RaiseLevel)
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
            var bet = gameState.CurrentBuyIn - gameState.Self.Bet;
            if(bet > gameState.Self.Stack * MaximumCallBet)
            {
                bet = 0;
            }

            return bet;
        }
    }
}
