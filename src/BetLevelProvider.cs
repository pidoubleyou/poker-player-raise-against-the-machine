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
            if(gameState.Players.Any(x => x.Name != Constants.PlayerName && x.HasRaisedHigh()))
            {
                return new HighRaiseBetLevel();
            }

            if(gameState.IsHeadsUp)
            {
                return new HeadsUpBetLevel();
            }


            return new DefaultBetLevel();
        }
    }
}
