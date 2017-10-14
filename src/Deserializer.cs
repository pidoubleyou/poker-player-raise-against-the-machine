using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class Deserializer
    {
        public GameState Deserialize(JObject gameStateJson)
        {
            var serializer = new JsonSerializer();
            var result = (GameState)serializer.Deserialize(new JTokenReader(gameStateJson), typeof(GameState));

            return result;
        }
    }
}
