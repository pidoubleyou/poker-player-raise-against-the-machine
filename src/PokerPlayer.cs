﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "I can fold, go all in and raise";

		public static int BetRequest(JObject gameStateJson)
		{
            Console.Write(gameStateJson.ToString());

            var deserializer = new Deserializer();
            var gameState = deserializer.Deserialize(gameStateJson);

            var eval = new Evaluator();
            var calculator = new BetCalculator();
            var betLevelProvider = new BetLevelProvider();

            var state = eval.GetScore(gameState.Self.Cards);
            return calculator.calculate(gameState, state, betLevelProvider.GetBetLevel(gameState));
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

