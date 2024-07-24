using CreditCardValidator.Business;
using CreditCardValidator.Common.Interfaces;
using System;
using Xunit;

namespace CreditCardValidator.Business.Test
{
    public class LuhnAlgorithmRuleTests
    {
        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberIsValid()
        {
            // Arrange
            var rule = new LuhnAlgorithmRule();
            string cardNumber = "4539578763621486"; // Valid card number

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number is Valid", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }

        [Fact]
        public void ValidateRule_ShouldReturnFailure_WhenCardNumberIsInvalid()
        {
            // Arrange
            var rule = new LuhnAlgorithmRule();
            string cardNumber = "4539578763621487"; // Invalid card number

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Card Number is Invalid", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }
       

        [Fact]
        public void ValidateRule_ShouldReturnSuccess_WhenCardNumberContainsSpaces()
        {
            // Arrange
            var rule = new LuhnAlgorithmRule();
            string cardNumber = "4539 5787 6362 1486".Replace(" ", ""); // Valid card number with spaces

            // Act
            ICardValidationResponse result = rule.ValidateRule(cardNumber);

            // Assert
            Assert.True(result.Success);
            Assert.Equal("Card Number is Valid", result.Message);
            Assert.Equal(cardNumber, result.CardNumber);
        }
   
    }
}
