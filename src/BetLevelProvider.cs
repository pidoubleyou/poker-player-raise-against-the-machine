using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class BetLevelProvider
    {
        public IBetLevel GetBetLevel(GameState gameState)
        {
            if(gameState.IsHeadsUp)
            {
                return new HeadsUpBetLevel();
            }

            return new DefaultBetLevel();
        }
    }
}
