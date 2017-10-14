using System;

namespace Nancy.Simple
{
    public static class CardValueExtensions
    {
        public static CardValue Parse(string value)
        {
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