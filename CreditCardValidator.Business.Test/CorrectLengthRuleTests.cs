using CreditCardValidator.Business;
using CreditCardValidator.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CreditCardValidator.Business.Test
{
    public class CorrectLengthRuleTests
    {
        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberLengthIs15()
        {
            // Arrange
            var rule = new CorrectLengthRule();
            string cardNumber = "123456789012345"; // 15 digits

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number Length is Valid", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberLengthIs16()
        {
            // Arrange
            var rule = new CorrectLengthRule();
            string cardNumber = "1234567890123456"; // 16 digits

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number Length is Valid", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnFailure_WhenCardNumberLengthIsNot15Or16()
        {
            // Arrange
            var rule = new CorrectLengthRule();
            string cardNumber = "12345678901234"; // 14 digits

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid Card Number Length", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnFailure_WhenCardNumberLengthIsGreaterThan16()
        {
            // Arrange
            var rule = new CorrectLengthRule();
            string cardNumber = "12345678901234567"; // 17 digits

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid Card Number Length", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }     

        [Fact]
        public void ValidateRule_ShouldReturnFailure_WhenCardNumberIsEmpty()
        {
            // Arrange
            var rule = new CorrectLengthRule();
            string cardNumber = string.Empty;

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Invalid Card Number Length", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }
    }
}

