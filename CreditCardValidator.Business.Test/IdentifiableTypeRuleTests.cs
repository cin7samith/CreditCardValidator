using CreditCardValidator.Business;
using CreditCardValidator.Common.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CreditCardValidator.Business.Test
{
    public class IdentifiableTypeRuleTests
    {
        private IList<ICardTypeInfo> GetCardTypeInfos()
        {
            var mockVisa = new Mock<ICardTypeInfo>();
            mockVisa.SetupGet(x => x.Name).Returns("Visa");
            mockVisa.SetupGet(x => x.Digits).Returns(16);
            mockVisa.SetupGet(x => x.RegEx).Returns("^4[0-9]{12}(?:[0-9]{3})?$");

            var mockMasterCard = new Mock<ICardTypeInfo>();
            mockMasterCard.SetupGet(x => x.Name).Returns("MasterCard");
            mockMasterCard.SetupGet(x => x.Digits).Returns(16);
            mockMasterCard.SetupGet(x => x.RegEx).Returns("^5[1-5][0-9]{14}$");

            var mockAmex = new Mock<ICardTypeInfo>();
            mockAmex.SetupGet(x => x.Name).Returns("Amex");
            mockAmex.SetupGet(x => x.Digits).Returns(15);
            mockAmex.SetupGet(x => x.RegEx).Returns("^3[47][0-9]{13}$");

            return new List<ICardTypeInfo> { mockVisa.Object, mockMasterCard.Object, mockAmex.Object };
        }

        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberIsVisa()
        {
            // Arrange
            var cardTypeInfos = GetCardTypeInfos();
            var rule = new IdentifiableTypeRule(cardTypeInfos);
            string cardNumber = "4111111111111111"; // Visa card

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number is a Visa type card", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberIsMasterCard()
        {
            // Arrange
            var cardTypeInfos = GetCardTypeInfos();
            var rule = new IdentifiableTypeRule(cardTypeInfos);
            string cardNumber = "5111111111111111"; // MasterCard card

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number is a MasterCard type card", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberIsAmex()
        {
            // Arrange
            var cardTypeInfos = GetCardTypeInfos();
            var rule = new IdentifiableTypeRule(cardTypeInfos);
            string cardNumber = "341111111111111"; // Amex card

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number is a Amex type card", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnFailure_WhenCardNumberIsInvalid()
        {
            // Arrange
            var cardTypeInfos = GetCardTypeInfos();
            var rule = new IdentifiableTypeRule(cardTypeInfos);
            string cardNumber = "1111111111111111"; // Invalid card

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid Characters in the Card Number", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }       

  
    }
}
