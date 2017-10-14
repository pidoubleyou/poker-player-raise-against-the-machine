﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;

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

        public void When2_EnumtwoExpected()
        {
            // Arrange
            string two = "2";
            CardValue cardValue = CardValue.A;

            // Act


            // Assert
            Assert.AreEqual(CardValue.two, cardValue);
        }
    }
}
