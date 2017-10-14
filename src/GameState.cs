using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public enum State
     {
        Fold,
        Call,
        Raise,
        AllIn
    }
    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
    }
    public class PlayerInfo
    {
        public string Name { get; set; }
        public int Stack { get; set; }
        [JsonProperty("hole_cards")]
        public Card[] Cards { get; set; }
    }

    public class GameState
    {
        [JsonProperty("small_blind")]
        public int SmallBlind { get; set; }
        [JsonProperty("current_buy_in")]
        public int CurrentBuyIn { get; set; }
        public int Pot { get; set; }
        public PlayerInfo[] Players { get; set; }
    }
}
