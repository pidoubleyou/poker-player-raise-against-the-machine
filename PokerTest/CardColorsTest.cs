using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;

namespace PokerTest
{
    [TestClass]
    public class CardColorsTest
    {
        [TestMethod]
        public void TestClubs()
        {
            // Arrange
            CardColors cardColor = CardColors.Spades;
            string clubs = "clubs";

            // Act
            CardColors.TryParse(clubs, true, out cardColor);

            // Assert
            Assert.AreEqual(CardColors.Clubs, cardColor);
        }
    }
}
