using System;

namespace Nancy.Simple
{
    public static class CardValueExtensions
    {
        public static CardValue Parse(string value)
        {
            const string j = "J";
            const string q = "Q";
            const string k = "K";
            const string a = "A";

            CardValue cardValueOut;
            int cardNumber;

            var isNumeric = Int32.TryParse(value, out cardNumber);

            if (isNumeric)
            {
                cardValueOut = (CardValue) cardNumber;
            }
            else
            {
                CardValue.TryParse(value, true, out cardValueOut);
            }

            return cardValueOut;
        }
    }
}