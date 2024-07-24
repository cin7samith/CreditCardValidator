using CreditCardValidator.Business;
using CreditCardValidator.Common.Interfaces;
using System;
using Xunit;

namespace CreditCardValidator.Business.Test
{
    public class NotEmptyOrNullRuleTests
    {
        [Fact]
        public void ValidateRule_ShouldReturnFailure_WhenCardNumberIsNull()
        {
            // Arrange
            var rule = new NotEmptyOrNullRule();
            string cardNumber = null;

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Card Number is Empty", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnFailure_WhenCardNumberIsEmpty()
        {
            // Arrange
            var rule = new NotEmptyOrNullRule();
            string cardNumber = string.Empty;

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Card Number is Empty", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberIsValid()
        {
            // Arrange
            var rule = new NotEmptyOrNullRule();
            string cardNumber = "1234567890123456";

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number is Valid", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }
    }
}
