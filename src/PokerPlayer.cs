using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "I can fold, go all in and raise";

		public static int BetRequest(JObject gameStateJson)
		{
            var deserializer = new Deserializer();
            var gameState = deserializer.Deserialize(gameStateJson);

            var eval = new Evaluator();
            var calculator = new BetCalculator();
            var allCards = new List<Card>();
            allCards.AddRange(gameState.Self.Cards);
            allCards.AddRange(gameState.CommunityCards);

            var state = eval.GetScore(allCards);
            return calculator.calculate(gameState, state);
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

