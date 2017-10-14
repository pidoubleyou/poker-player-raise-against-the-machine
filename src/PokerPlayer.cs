using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Playing from Dusk till Dawn";

		public static int BetRequest(JObject gameStateJson)
		{
            var deserializer = new Deserializer();
            var gameState = deserializer.Deserialize(gameStateJson);

            var eval = new Evaluator();
            var state = eval.GetScore(gameState.Self.Cards);
            switch(state)
            {
                case State.Fold:
                    return 0;
                default:
                    return 1000;
            }
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

