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

        public int Value
        {
            get
            {
                CardValue value = CardValueExtensions.Parse(Rank);
                return (int)value;
            }
        }
    }

    public class PlayerInfo
    {
        public int Bet { get; set; }
        public string Name { get; set; }
        public int Stack { get; set; }
        public string Status { get; set; }
        [JsonProperty("hole_cards")]
        public Card[] Cards { get; set; }
    }

    public class GameState
    {
        [JsonProperty("small_blind")]
        public int SmallBlind { get; set; }
        [JsonProperty("current_buy_in")]
        public int CurrentBuyIn { get; set; }
        [JsonProperty("minimum_raise")]
        public int MinimumRaise { get; set; }
        public int Pot { get; set; }
        [JsonProperty("community_cards")]
        public Card[] CommunityCards { get; set; }
        public PlayerInfo[] Players { get; set; }

        public PlayerInfo Self { get
            {
                return Players.FirstOrDefault(x => x.Name == Constants.PlayerName);
            }
        }
    }
}
