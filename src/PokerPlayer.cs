﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "high raise strategy";

		public static int BetRequest(JObject gameStateJson)
		{
            Console.Write(gameStateJson.ToString());

            var deserializer = new Deserializer();
            var gameState = deserializer.Deserialize(gameStateJson);

            var eval = new Evaluator();
            var calculator = new BetCalculator();
            var betLevelProvider = new BetLevelProvider();

            var allCards = new List<Card>();
            allCards.AddRange(gameState.Self.Cards);
            allCards.AddRange(gameState.CommunityCards);

            var state = eval.GetScore(allCards);

            return calculator.calculate(gameState, state, betLevelProvider.GetBetLevel(gameState));
        }

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}
	}
}

