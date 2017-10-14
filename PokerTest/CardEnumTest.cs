using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using Newtonsoft.Json.Linq;

namespace PokerTest
{
    [TestClass]
    public class CardEnumTest
    {
        [TestMethod]
        public void TestClubs()
        {
            // Arrange
            CardEnums cardColor = CardEnums.Spades;
            string clubs = "clubs";

            // Act
            CardEnums.TryParse(clubs, true, out cardColor);

            // Assert
            Assert.AreEqual(CardEnums.Clubs, cardColor);
        }

        [TestMethod]
        public void When2_EnumtwoExpected()
        {
            // Arrange
            string two = "2";

            // Act
            var cardValue = CardValueExtensions.Parse(two);

            // Assert
            Assert.AreEqual(CardValue.two, cardValue);
        }

        [TestMethod]
        public void WhenK_EnumtwoExpected()
        {
            // Arrange
            string k = "K";

            // Act
            var cardValue = CardValueExtensions.Parse(k);

            // Assert
            Assert.AreEqual(CardValue.K, cardValue);
        }
    }
}
