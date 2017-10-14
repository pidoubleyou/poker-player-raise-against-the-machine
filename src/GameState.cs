using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
    }
    public class PlayerInfo
    {
        public string Name { get; set; }
        public int Stack { get; set; }
        public Card[] Cards { get; set; }
    }

    public class GameState
    {
        public int SmallBlind { get; set; }
        public int CurrentBuyIn { get; set; }
        public int Pot { get; set; }
        public PlayerInfo Player { get; set; }


    }
}
